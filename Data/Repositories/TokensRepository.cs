using Data.Repositories.Abstract;
using Entities;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class TokensRepository : ITokensRepository
    {
        private readonly DatabaseContext _databaseContext;
        public TokensRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task CreateTokenAsync(TokenEntity token)
        {
            await _databaseContext.Tokens.AddAsync(token);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<bool> IsValidRefreshTokenAsync(int id, string refresh)
        {
            var exists = await _databaseContext.Tokens
                .Where(x => x.UserId == id &&
                x.RefreshToken == refresh &&
                x.Used == false &&
                x.ExpiryDate > DateTime.Now &&
                x.CreatedDate < DateTime.Now).FirstOrDefaultAsync();

            if (exists is not null)
            {
                exists.Used = true;
                await _databaseContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
