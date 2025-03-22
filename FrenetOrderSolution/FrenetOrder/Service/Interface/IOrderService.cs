using FrenetOrder.Models.Dto;
using FrenetOrder.Models.Entity;

namespace FrenetOrder.Service.Interface
{
    public interface IOrderService
    {
        public Task<Order> GetById(int id);
        public Task<List<Order>> Get();
        public Task Update(int id, OrderUpdateInput order);
        public Task<Order> Create(OrderInput order);
        public Task Remove(int id);

    }
}
