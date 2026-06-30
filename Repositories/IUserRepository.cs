using empService.Entities;

namespace empService.Repositories
{
    public interface IUserRepository
    {
        User Add(User user);

        List<User> GetAll();

        User? GetById(int id);

        void Delete(User user);

        void Save();
    }
}