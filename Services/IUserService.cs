using empService.DTOs;
using empService.Entities;

namespace empService.Services
{
    public interface IUserService
    {
        User CreateUser(CreateUserRequest dto);
        List<User> GetAllUsers();
        User GetUserById(int id);

        User UpdateUserEmail(int id, string email);

        void DeleteUserByID(int id);
    }
}