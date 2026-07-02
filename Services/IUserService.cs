using empService.DTOs;
using empService.Entities;

namespace empService.Services
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(CreateUserRequest dto);
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);

        Task<User> UpdateUserEmailAsync(int id, string email);

        Task DeleteUserByIDAsync(int id);
    }
}