using FrenetOrder.Models.Dto;
using FrenetOrder.Models.Entity;
using FrenetOrder.Repository.Interface;
using FrenetOrder.Service;
using Moq;
using Xunit;
using Assert = Xunit.Assert;

namespace FrenetOrder.Tests.Service
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
            // Arrange
            var customerInput = new CustomerInput
            {
                Nome = "John Doe",
                Endereco = "123 Main St",
                Telefone = "1234567890",
                Email = "john.doe@example.com"
            };

            var customer = new Customer
            {
                Id = 1,
                Nome = customerInput.Nome,
                Endereco = customerInput.Endereco,
                Telefone = customerInput.Telefone,
                Email = customerInput.Email
            };

            _customerRepositoryMock.Setup(repo => repo.Create(It.IsAny<Customer>())).ReturnsAsync(customer);

            // Act
            var result = await _customerService.Create(customerInput);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(customerInput.Nome, result.Nome);
            Assert.Equal(customerInput.Endereco, result.Endereco);
            Assert.Equal(customerInput.Telefone, result.Telefone);
            Assert.Equal(customerInput.Email, result.Email);
        }

        [Fact]
        public async Task GetById_ShouldReturnCustomer_WhenIdIsValid()
        {
            // Arrange
            var customerId = 1;
            var customer = new Customer
            {
                Id = customerId,
                Nome = "John Doe",
                Endereco = "123 Main St",
                Telefone = "1234567890",
                Email = "john.doe@example.com"
            };

            _customerRepositoryMock.Setup(repo => repo.GetById(customerId)).ReturnsAsync(customer);

            // Act
            var result = await _customerService.GetById(customerId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(customerId, result.Id);
        }

        [Fact]
        public async Task GetById_ShouldThrowException_WhenIdIsInvalid()
        {
            // Arrange
            var customerId = -1;

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _customerService.GetById(customerId));
        }

        [Fact]
        public async Task Get_ShouldReturnAllCustomers()
        {
            // Arrange
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Nome = "John Doe", Endereco = "123 Main St", Telefone = "1234567890", Email = "john.doe@example.com" },
                new Customer { Id = 2, Nome = "Jane Doe", Endereco = "456 Elm St", Telefone = "0987654321", Email = "jane.doe@example.com" }
            };

            _customerRepositoryMock.Setup(repo => repo.Get()).ReturnsAsync(customers);

            // Act
            var result = await _customerService.Get();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task Update_ShouldUpdateCustomer()
        {
            // Arrange
            var customerId = 1;
            var customerInput = new CustomerInput
            {
                Nome = "John Doe Updated",
                Endereco = "123 Main St Updated",
                Telefone = "1234567890",
                Email = "john.doe.updated@example.com"
            };

            _customerRepositoryMock.Setup(repo => repo.Update(customerId, customerInput)).Returns(Task.CompletedTask);

            // Act
            await _customerService.Update(customerId, customerInput);

            // Assert
            _customerRepositoryMock.Verify(repo => repo.Update(customerId, customerInput), Times.Once);
        }

        [Fact]
        public async Task Update_ShouldThrowException_WhenIdIsInvalid()
        {
            // Arrange
            var customerId = -1;
            var customerInput = new CustomerInput
            {
                Nome = "John Doe Updated",
                Endereco = "123 Main St Updated",
                Telefone = "1234567890",
                Email = "john.doe.updated@example.com"
            };

            // Act & Assert
            await Xunit.Assert.ThrowsAsync<Exception>(() => _customerService.Update(customerId, customerInput));
        }

        [Fact]
        public async Task Remove_ShouldRemoveCustomer()
        {
            // Arrange
            var customerId = 1;

            _customerRepositoryMock.Setup(repo => repo.Remove(customerId)).Returns(Task.CompletedTask);

            // Act
            await _customerService.Remove(customerId);

            // Assert
            _customerRepositoryMock.Verify(repo => repo.Remove(customerId), Times.Once);
        }

        [Fact]
        public async Task Remove_ShouldThrowException_WhenIdIsInvalid()
        {
            // Arrange
            var customerId = -1;

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _customerService.Remove(customerId));
        }
    }
}
