using empService.Data;
using empService.Entities;

namespace empService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;

        }
        User IUserRepository.Add(User user)
        {
            _dbContext.Users.Add(user);

            return user;

        }

        void IUserRepository.Delete(User user)
        {
            _dbContext.Users.Remove(user);
        }

        List<User> IUserRepository.GetAll()
        {
            return _dbContext.Users.Where(user => string.IsNullOrEmpty(user.Email) == false && user.Email.EndsWith("@gmail.com") && user.Name.StartsWith("A")).ToList();


        }

        User? IUserRepository.GetById(int id)
        {
            return _dbContext.Users.Find(id);
        }

        void IUserRepository.Save()
        {
            _dbContext.SaveChanges();

        }
    }
}