using FrenetOrder.Models.Dto;
using FrenetOrder.Models.Entity;

namespace FrenetOrder.Service.Interface
{
    public interface IUserService
    {
        public Task<string> Login(string login, string password);
        public Task<User> Create(UserCreateInput user);
        public Task Remove(string login);
    }
}
