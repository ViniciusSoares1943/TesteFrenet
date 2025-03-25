using FrenetOrder.Models.Dto;
using FrenetOrder.Models.Entity;
using FrenetOrder.Repository.Interface;
using FrenetOrder.Service;
using FrenetOrder.Service.Interface;
using Moq;
using Xunit;
using Assert = Xunit.Assert;

namespace FrenetOrderTest.Service
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IJwtService> _jwtServiceMock;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _jwtServiceMock = new Mock<IJwtService>();
            _userService = new UserService(_userRepositoryMock.Object, _jwtServiceMock.Object);
        }

        [Fact]
        public async Task Login_ShouldLogin()
        {
            string login = "usuario";
            string password = "password";

            User user = new()
            {
                Id = 1,
                Login = "login",
                Senha = "senha"
            };

            string token = "iuojhgrwjiogrwoijgfdioj";

            _userRepositoryMock.Setup(x => x.Login(login, password)).ReturnsAsync(user);
            _jwtServiceMock.Setup(x => x.GenerateToken(It.IsAny<string>(), It.IsAny<string>())).Returns(token);

            var result = await _userService.Login(login, password);

            Assert.NotNull(result);
            Assert.Equal(token, result);
        }

        [Fact]
        public async Task Create_ShouldCreateUser()
        {
            UserCreateInput userCreateInput = new()
            {
                Login = "login",
                Senha = "senha"
            };

            User user = new()
            {
                Id = 1,
                Login = "login",
                Senha = "senha"
            };

            _userRepositoryMock.Setup(x => x.Create(It.IsAny<User>())).ReturnsAsync(user);

            var result = await _userService.Create(userCreateInput);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Create_ShouldThrowException_WhenPasswordIsInvalid()
        {
            UserCreateInput userCreateInput = new()
            {
                Login = "login",
                Senha = "1"
            };

            await Assert.ThrowsAsync<Exception>(() => _userService.Create(userCreateInput));
        }

        [Fact]
        public async Task Create_ShouldThrowException_WhenLoginIsInvalid()
        {
            UserCreateInput userCreateInput = new()
            {
                Login = "  ",
                Senha = "senha"
            };

            await Assert.ThrowsAsync<Exception>(() => _userService.Create(userCreateInput));
        }

        [Fact]
        public async Task Remove_ShouldRemoveUser()
        {
            string login = "login";
                
            _userRepositoryMock.Setup(x => x.Remove(login)).Returns(Task.CompletedTask);

            await _userService.Remove(login);

            _userRepositoryMock.Verify(x => x.Remove(login), Times.Once);
        }

        [Fact]
        public async Task Remove_ShouldThrowException_WhenLoginIsInvalid()
        {
            string login = "  ";

            await Assert.ThrowsAsync<Exception>(() => _userService.Remove(login));
        }
    }
}
