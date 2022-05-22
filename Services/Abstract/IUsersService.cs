using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IUsersService
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByLoginPasswordAsync(string login, string password);
    }
}
