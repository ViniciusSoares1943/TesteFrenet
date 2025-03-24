using FrenetOrder.Models.Entity;

namespace FrenetOrder.Repository.Interface
{
    public interface IUserRepository
    {
        public Task<User> GetByLogin(string login);
        public Task<User> Login(string login, string password);
        public Task<User> Create(User user);
        public Task Remove(string login);
    }
}
