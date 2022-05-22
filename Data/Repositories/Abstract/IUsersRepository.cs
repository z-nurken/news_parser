using Entities;
using System.Threading.Tasks;

namespace Data.Repositories.Abstract
{
    public interface IUsersRepository
    {
        Task<UserEntity> GetUserByIdAsync(int id);
        Task<UserEntity> GetUserByLoginPasswordAsync(string login, string password);
    }
}
