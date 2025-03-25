
using FrenetOrder.Models.Dto;
using FrenetOrder.Models.Entity;
using FrenetOrder.Models.Enum;
using FrenetOrder.Repository.Interface;
using FrenetOrder.Service;
using FrenetOrder.Service.Interface;
using Moq;
using Xunit;
using Assert = Xunit.Assert;

namespace FrenetOrderTest.Service
{
    public class OrderServiceTests
    {
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly Mock<ICustomerService> _customerServiceMock;
        private readonly OrderService _orderService;
        public OrderServiceTests()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _customerServiceMock = new Mock<ICustomerService>();
            _orderService = new OrderService( _orderRepositoryMock.Object, _customerServiceMock.Object );
        }

        [Fact]
        public async Task GetById_SholdReturnOrder_WhenIdIsValid()
        {
            int orderId = 1;

            //mock
            var order = new Order
            {
                Id = 1,
                DataCriacao = DateTime.Now,
                Origem = "Ponto inicial",
                Destino = "Ponto final",
                IdCliente = 1,
                Status = OrderStatus.Processing,
            };
            _orderRepositoryMock.Setup(x => x.GetById(orderId)).ReturnsAsync(order);

            var result = await _orderService.GetById(orderId);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetById_SholdThrowException_WhenIdIsInvalid()
        {
            int orderId = -1;

            await Assert.ThrowsAsync<Exception>(() => _orderService.GetById(orderId));
        }

        [Fact]
        public async Task Get_SholdReturnAllOrder()
        {
            //mock
            List<Order> orders =
            [
                new () { Id = 1, DataCriacao = DateTime.Now, Origem = "Ponto inicial", Destino = "Ponto final", IdCliente = 1, Status = OrderStatus.Processing },
                new () { Id = 2, DataCriacao = DateTime.Now, Origem = "Segundo ponto", Destino = "Terceiro", IdCliente = 2, Status = OrderStatus.Shipped }
            ];

            _orderRepositoryMock.Setup(x => x.Get()).ReturnsAsync(orders);

            var result = await _orderService.Get();

            Assert.NotNull(result);
            Assert.Equal(result.Count, orders.Count);
        }

        [Fact]
        public async Task Update_ShouldUpdateOrder()
        {
            int orderId = 1;
            Order order = new ()
            {
                Id = orderId,
                DataCriacao = DateTime.Now,
                Origem = "Nova Origem",
                Destino = "Novo Destino",
                Status = OrderStatus.Delivered,
                IdCliente = 1,
            };

            OrderUpdateInput orderUpdateInput = new ()
            {
                Origem = "Nova Origem",
                Destino = "Novo Destino",
                Status = OrderStatus.Delivered,
            };

            _orderRepositoryMock.Setup(x => x.Update(orderId, orderUpdateInput)).Returns(Task.CompletedTask);

            await _orderService.Update(orderId, orderUpdateInput);

            _orderRepositoryMock.Verify(x => x.Update(orderId, orderUpdateInput), Times.Once());
        }

        [Fact]
        public async Task Update_ShouldException_WhenIdIsInvalid()
        {
            int orderId = -1;

            OrderUpdateInput orderUpdateInput = new ()
            {
                Origem = "Nova Origem",
                Destino = "Novo Destino",
                Status = OrderStatus.Delivered,
            };

            await Assert.ThrowsAsync<Exception>(() => _orderService.Update(orderId, orderUpdateInput));
        }

        [Fact]
        public async Task Create_ShouldCreateOrder()
        {
            int idCliente = 1;
            OrderInput orderInput = new ()
            {
                Origem = "Ponto de origem",
                Destino = "Ponto de destio",
                IdCliente = idCliente,
                Status = OrderStatus.Processing
            };

            Customer customer = new ()
            {
                Id = idCliente,
                Nome = "Fulano de tal da silva",
                Endereco = "Rua das ruas 123",
                Telefone = "99 99999-9999",
                Email = "fulano@email.com",
            };

            Order order = new ()
            {
                Id = 1,
                Origem = "Ponto de origem",
                Destino = "Ponto de destio",
                IdCliente = idCliente,
                Status = OrderStatus.Processing,
                DataCriacao = DateTime.Now
            };

            _customerServiceMock.Setup(x => x.GetById(idCliente)).ReturnsAsync(customer);
            _orderRepositoryMock.Setup(x => x.Create(It.IsAny<Order>())).ReturnsAsync(order);

            var result = await _orderService.Create(orderInput);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Create_ShouldThrowException_WhenIdClienteIsInvalid()
        {
            int idCliente = -1;
            OrderInput orderInput = new ()
            {
                Origem = "Ponto de origem",
                Destino = "Ponto de destio",
                IdCliente = idCliente,
                Status = OrderStatus.Processing
            };

            await Assert.ThrowsAsync<Exception>(() => _orderService.Create(orderInput));
        }

        [Fact]
        public async Task Create_ShouldThrowException_WhenCustomerNotFound()
        {
            int idCliente = int.MaxValue;
            OrderInput orderInput = new ()
            {
                Origem = "Ponto de origem",
                Destino = "Ponto de destio",
                IdCliente = idCliente,
                Status = OrderStatus.Processing
            };

#pragma warning disable CS8600, CS8620
            _customerServiceMock.Setup(x => x.GetById(idCliente)).ReturnsAsync((Customer)null);
#pragma warning restore CS8600, CS8620

            await Assert.ThrowsAsync<Exception>(() => _orderService.Create(orderInput));
        }

        [Fact]
        public async Task Remove_ShoulRemoveOrder_WhenIdIsValid()
        {
            int orderId = 1;

            _orderRepositoryMock.Setup(x => x.Remove(orderId)).Returns(Task.CompletedTask);

            await _orderService.Remove(orderId);

            _orderRepositoryMock.Verify(x => x.Remove(orderId), Times.Once());
        }

        [Fact]
        public async Task Remove_ShouldThrowException_WhenIdIsNotValid()
        {
            int orderId = -1;

            await Assert.ThrowsAsync<Exception>(() => _orderService.Remove(orderId));
        }

    }
}
