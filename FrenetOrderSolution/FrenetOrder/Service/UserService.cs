using FrenetOrder.Models.Dto;
using FrenetOrder.Models.Entity;
using FrenetOrder.Repository.Interface;
using FrenetOrder.Service.Interface;

namespace FrenetOrder.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;
        public UserService(IUserRepository userRepository, JwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<string> Login(string login, string password)
        {
            var user = await _userRepository.Login(login, password);

            var tokenJwt = _jwtService.GenerateToken(user.Id.ToString(), user.Login);
            return tokenJwt;
        }

        public async Task<User> Create(UserCreateInput user)
        {
            if (user.Senha.Count() < 5)
            {
                throw new Exception("Erro ao criar usuário, senha precisar ter mais de 5 caracteres");
            }

            var userResult = await _userRepository.Create(new User
            {
                Login = user.Login,
                Senha = user.Senha,
            });

            return userResult;
        }

        public async Task Remove(string login)
        {
            await _userRepository.Remove(login);
        }
    }
}
