using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface ITokensService
    {
        Task<Token> CreateTokenAsync(User user);
        ClaimsPrincipal GetClaimsByExpiredAccess(string access);
        Task<bool> IsValidRefreshTokenAsync(int id, string refresh);
    }
}
