using Data.Repositories.Abstract;
using Domain;
using Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TokensService : ITokensService
    {
        private readonly ITokensRepository _tokensRepository;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokensService(ITokensRepository tokensRepository, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _tokensRepository = tokensRepository;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Token> CreateTokenAsync(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Login)
            };

            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.Add(TimeSpan.Parse(_configuration["JwtAccessLifeTime"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtAudience"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            string accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            string userIpAddress = _httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress?.ToString();
            string userAgent = _httpContextAccessor?.HttpContext?.Request.Headers["User-Agent"].ToString();

            var newToken = new Token()
            {
                RefreshToken = GenerateRefresh(),
                AccessToken = accessToken,
                UserId = user.Id,
                ExpiryDate = DateTime.Now.Add(TimeSpan.Parse(_configuration["JwtRefreshLifeTime"])),
                RemoteIpAddress = userIpAddress,
                UserAgent = userAgent
            };

            await _tokensRepository.CreateTokenAsync(newToken.ToEntity());

            return newToken;
        }

        public ClaimsPrincipal GetClaimsByExpiredAccess(string access)
        {
            TokenValidationParameters tokenValidationParameters = new()
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"])),
                ValidateLifetime = true,
                ValidIssuer = _configuration["JwtIssuer"],
                ValidAudience = _configuration["JwtAudience"]
            };

            JwtSecurityTokenHandler tokenHandler = new();

            try
            {

                ClaimsPrincipal principal = tokenHandler.ValidateToken(access, tokenValidationParameters, out SecurityToken securityToken);
                if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    return null;

                return principal;
            }
            catch (SecurityTokenException)
            {
                return null;
            }
        }

        public async Task<bool> IsValidRefreshTokenAsync(int id, string refresh)
        {
            var isValid = await _tokensRepository.IsValidRefreshTokenAsync(id, refresh);

            return isValid;
        }

        private string GenerateRefresh(int size = 32)
        {
            byte[] randomNumber = new byte[size];
            using RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }
    }
}
