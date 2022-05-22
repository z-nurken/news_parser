using Data.Repositories.Abstract;
using Domain;
using Mappers;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _usersRepository.GetUserByIdAsync(id);

            return user.ToDomain();
        }

        public async Task<User> GetUserByLoginPasswordAsync(string login, string password)
        {
            var user = await _usersRepository.GetUserByLoginPasswordAsync(login, password);

            return user.ToDomain();
        }
    }
}
