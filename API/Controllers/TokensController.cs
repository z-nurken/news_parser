using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Abstract;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        private readonly ITokensService _tokensService;
        private readonly IUsersService _usersService;
        public TokensController(IUsersService usersService, ITokensService tokensService)
        {
            _usersService = usersService;
            _tokensService = tokensService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody] AccountModel model)
        {
            User user = await _usersService.GetUserByLoginPasswordAsync(model.Login, model.Password);

            if (user != null)
            {
                Token result = await _tokensService.CreateTokenAsync(user);

                return Ok(result);
            }

            return BadRequest("User not found");
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> UpdateToken(TokenModel model)
        {
            ClaimsPrincipal claims = _tokensService.GetClaimsByExpiredAccess(model.Access);

            if (claims != null)
            {
                int userId = int.Parse(claims.FindFirst(ClaimTypes.NameIdentifier).Value);

                User user =  await _usersService.GetUserByIdAsync(userId);

                bool isValidRefreshToken = await _tokensService.IsValidRefreshTokenAsync(userId, model.Refresh);

                if (isValidRefreshToken)
                {
                    Token result = await _tokensService.CreateTokenAsync(user);

                    return Ok(result);
                }
            }

            return BadRequest("User Token Expired");
        }
    }
}
