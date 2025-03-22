using FrenetOrder.Models.Dto;
using FrenetOrder.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace FrenetOrder.Repository.Interface
{
    public interface IOrderRepository
    {
        public Task<Order> GetById(int id);
        public Task<List<Order>> Get();
        public Task Update(int id, OrderUpdateInput order);
        public Task<Order> Create(Order order);
        public Task Remove(int id);

    }
}
