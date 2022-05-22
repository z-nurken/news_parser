using Data.Repositories.Abstract;
using Entities;
using EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DatabaseContext _databaseContext;
        public UsersRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<UserEntity> GetUserByIdAsync(int id)
        {
            var user = await _databaseContext.Users
                .FirstOrDefaultAsync(x => x.Id.Equals(id));

            return user;
        }

        public async Task<UserEntity> GetUserByLoginPasswordAsync(string login, string password)
        {
            UserEntity user = await _databaseContext.Users
                .FirstOrDefaultAsync(u => u.Login.Equals(login));

            if (user is not null)
            {
                PasswordHasher<UserEntity> hasher = new PasswordHasher<UserEntity>();

                PasswordVerificationResult result = hasher.VerifyHashedPassword(user, user.PasswordHash, password);

                return result == PasswordVerificationResult.Failed ? null : user;
            }

            return user;
        }
    }
}
