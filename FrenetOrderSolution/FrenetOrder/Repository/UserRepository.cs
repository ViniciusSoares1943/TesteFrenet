using FrenetOrder.Data;
using FrenetOrder.Models.Entity;
using FrenetOrder.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace FrenetOrder.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextClass _context;
        public UserRepository(DbContextClass context)
        {
            _context = context;
        }

        public async Task<User> GetByLogin(string login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Login.ToLower().Equals(login.ToLower()));

            return user ?? throw new Exception($"Usuário não encontrado com este login {login}");
        }

        public async Task<User> Login(string login, string password)
        {
            var user = await GetByLogin(login);

            var hashedPassword = HashPassword(password);

            if (user.Senha != hashedPassword)
            {
                throw new Exception($"Erro ao realizar login, senha incorreta!");
            }

            return user;
        }

        public async Task<User> Create(User user)
        {
            user.Login = user.Login.ToLower();
            user.Senha = HashPassword(user.Senha);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            user.Senha = "********";
            return user;
        }

        public async Task Remove(string login)
        {
            var user = await GetByLogin(login);

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        private static string HashPassword(string password)
        {
            var byteValue = Encoding.UTF8.GetBytes(password);
            var byteHash = SHA256.HashData(byteValue);
            return Convert.ToBase64String(byteHash);
        }

    }
}
