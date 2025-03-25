using FrenetOrder.Models.Dto;
using FrenetOrder.Models.Entity;
using FrenetOrder.Repository.Interface;
using FrenetOrder.Service;
using Moq;
using Xunit;
using Assert = Xunit.Assert;

namespace FrenetOrderTest.Service
{
    public class CustomerServiceTests
    {
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly CustomerService _customerService;

        public CustomerServiceTests()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _customerService = new CustomerService(_customerRepositoryMock.Object);
        }

        [Fact]
        public async Task Create_ShouldCreateCustomer()
        {
            var customerInput = new CustomerInput
            {
                Nome = "Fulano de tal da silva",
                Endereco = "Rua das ruas 123",
                Telefone = "99 99999-9999",
                Email = "fulano@email.com"
            };

            //Mock Repository
            var customer = new Customer
            {
                Id = 1,
                Nome = customerInput.Nome,
                Endereco = customerInput.Endereco,
                Telefone = customerInput.Telefone,
                Email = customerInput.Email
            };
            _customerRepositoryMock.Setup(r => r.Create(It.IsAny<Customer>())).ReturnsAsync(customer);

            var result = await _customerService.Create(customerInput);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetById_ShouldReturnCustomer_WhenIdIsValid()
        {
            //mock
            var customerId = 1;
            var customer = new Customer
            {
                Id = customerId,
                Nome = "Fulano de tal da silva",
                Endereco = "Rua das ruas 123",
                Telefone = "99 99999-9999",
                Email = "fulano@email.com"
            };
            _customerRepositoryMock.Setup(repo => repo.GetById(customerId)).ReturnsAsync(customer);

            var result = await _customerService.GetById(customerId);

            Assert.NotNull(result);
            Assert.Equal(customerId, result.Id);
        }

        [Fact]
        public async Task GetById_ShouldThrowException_WhenIdIsInvalid()
        {
            var customerId = -1;

            await Assert.ThrowsAsync<Exception>(() => _customerService.GetById(customerId));
        }

        [Fact]
        public async Task Get_ShouldReturnAllCustomers()
        {
            //mock
            var customers = new List<Customer>
            {
                new () { Id = 1, Nome = "Fulano de tal", Endereco = "Rua das ruas 123", Telefone = "99 99999-9999", Email = "fulano@email.com" },
                new () { Id = 2, Nome = "Ciclano de tal", Endereco = "Rua das avenidas 123", Telefone = "99 99999-9999", Email = "ciclano@email.com" }
            };
            _customerRepositoryMock.Setup(repo => repo.Get()).ReturnsAsync(customers);

            var result = await _customerService.Get();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task Update_ShouldUpdateCustomer()
        {
            var customerId = 1;
            var customerInput = new CustomerInput
            {
                Nome = "Fulano de tal da silva",
                Endereco = "Rua das ruas 123",
                Telefone = "99 99999-9999",
                Email = "fulano@email.com"
            };
            _customerRepositoryMock.Setup(repo => repo.Update(customerId, customerInput)).Returns(Task.CompletedTask);

            await _customerService.Update(customerId, customerInput);

            _customerRepositoryMock.Verify(repo => repo.Update(customerId, customerInput), Times.Once);
        }

        [Fact]
        public async Task Update_ShouldThrowException_WhenIdIsInvalid()
        {
            //mock
            var customerId = -1;
            var customerInput = new CustomerInput
            {
                Nome = "Fulano de tal da silva junior",
                Endereco = "Rua das avenidas 123",
                Telefone = "00 00000-0000s",
                Email = "fulano.silva@email.com"
            };

            await Assert.ThrowsAsync<Exception>(() => _customerService.Update(customerId, customerInput));
        }

        [Fact]
        public async Task Remove_ShouldRemoveCustomer()
        {
            //mock
            var customerId = 1;
            _customerRepositoryMock.Setup(repo => repo.Remove(customerId)).Returns(Task.CompletedTask);

            await _customerService.Remove(customerId);
            _customerRepositoryMock.Verify(repo => repo.Remove(customerId), Times.Once);
        }

        [Fact]
        public async Task Remove_ShouldThrowException_WhenIdIsInvalid()
        {
            var customerId = -1;

            await Assert.ThrowsAsync<Exception>(() => _customerService.Remove(customerId));
        }
    }
}
