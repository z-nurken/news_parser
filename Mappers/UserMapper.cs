using Domain;
using Entities;

namespace Mappers
{
    public static class UserMapper
    {
        public static UserEntity ToEntity(this User user)
        {
            if (user is null) return null;

            return new UserEntity
            {

            };
        }

        public static User ToDomain(this UserEntity user)
        {
            if (user is null) return null;

            return new User
            {
                Id = user.Id,
                Login = user.Login
            };
        }
    }
}
