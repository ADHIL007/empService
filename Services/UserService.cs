using empService.DTOs;
using empService.Entities;
using empService.Repositories;

namespace empService.Services
{
    public class UserService(IUserRepository userRepository, IUserCacheService userCacheService) : IUserService
    {


        private readonly IUserRepository _userRepository = userRepository;
        private readonly IUserCacheService _userCacheService = userCacheService;
        public User CreateUser(CreateUserRequest dto)
        {
            var user = new User
            {

                Name = dto.Name,
                Email = dto.Email

            };

            _userRepository.Add(user);
            _userRepository.Save();
            return user;

        }

        public List<User> GetAllUsers()
        {
            if (!_userCacheService.CheckCacheEmpty())
            {
                Console.WriteLine("Users retrieved from cache.");
                return _userCacheService.GetAllUsers();
            }
            else
            {
                Console.WriteLine("Users retrieved from repository.");
                var users = _userRepository.GetAll();
                foreach (var user in users)
                {
                    _userCacheService.AddUserToCache(user);
                }
                return users;
            }
        }

        public User GetUserById(int id)
        {
            var user = _userCacheService.GetUserFromCache(id);
            if (user != null)
            {
                Console.WriteLine("User retrieved from cache.");
                return user;
            }
            else
            {
                Console.WriteLine("User retrieved from repository.");
                var userFromRepo = _userRepository.GetById(id) ?? throw new KeyNotFoundException("User not found");
                _userCacheService.AddUserToCache(userFromRepo);
                return userFromRepo;
            }
        }

        public User UpdateUserEmail(int id, string email)
        {
            User user = _userRepository.GetById(id) ?? throw new KeyNotFoundException("User not found");
            user.Email = email;

            _userRepository.Save();
            _userCacheService.AddOrUpdateCache(user);
            return user;
        }

        public void DeleteUserByID(int id)
        {

            var user = _userRepository.GetById(id) ?? throw new KeyNotFoundException("User not found");


            _userRepository.Delete(user);

            _userRepository.Save();
            _userCacheService.RemoveUserFromCache(id);

        }
    }

}