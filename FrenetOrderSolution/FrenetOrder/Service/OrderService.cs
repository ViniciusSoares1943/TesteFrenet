using FrenetOrder.Models.Dto;
using FrenetOrder.Models.Entity;
using FrenetOrder.Repository;
using FrenetOrder.Repository.Interface;
using FrenetOrder.Service.Interface;

namespace FrenetOrder.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerService _customerService;
        public OrderService(IOrderRepository orderRepository, ICustomerService customerService)
        {
            _orderRepository = orderRepository;
            _customerService = customerService;

        }

        public async Task<Order> GetById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Operação não permitida, identificador não pode ser menor que zero");
            }

            return await _orderRepository.GetById(id);
        }

        public async Task<List<Order>> Get()
        {
            return await _orderRepository.Get();
        }

        public async Task Update(int id, OrderUpdateInput orderInput)
        {
            if (id <= 0)
            {
                throw new Exception("Operação não permitida, identificador não pode ser menor que zero");
            }

            await _orderRepository.Update(id, orderInput);
        }

        public async Task<Order> Create(OrderInput orderInput)
        {
            if (orderInput.IdCliente <= 0)
            {
                throw new Exception("Operação não permitida, identificador cliente inválido");
            }

            var customer = await _customerService.GetById(orderInput.IdCliente);

            if (customer == null)
            {
                throw new Exception("Erro ao criar pedido, cliente não encontrado!");
            }

            var orderResult = await _orderRepository.Create(new Order
            {
                Cliente = customer,
                IdClient = customer.Id,
                DataCriacao = DateTime.Now,
                Destino = orderInput.Destino,
                Origem = orderInput.Origem
            });

            return orderResult;
        }

        public async Task Remove(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Operação não permitida, identificador não pode ser menor que zero");
            }

            await _orderRepository.Remove(id);
        }

    }
}
