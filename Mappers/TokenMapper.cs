using Domain;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappers
{
    public static class TokenMapper
    {
        public static TokenEntity ToEntity(this Token token)
        {
            if (token is null) return null;

            return new TokenEntity
            {
                RefreshToken = token.RefreshToken,
                UserId = token.UserId,
                ExpiryDate = token.ExpiryDate,
                RemoteIpAddress = token.RemoteIpAddress,
                UserAgent = token.RemoteIpAddress
            };
        }
    }
}
