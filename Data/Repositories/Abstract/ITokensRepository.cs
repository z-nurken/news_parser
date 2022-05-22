using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Abstract
{
    public interface ITokensRepository
    {
        Task CreateTokenAsync(TokenEntity token);
        Task<bool> IsValidRefreshTokenAsync(int id, string refresh);
    }
}
