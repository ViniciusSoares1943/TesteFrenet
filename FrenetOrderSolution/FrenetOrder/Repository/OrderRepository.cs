using FrenetOrder.Data;
using FrenetOrder.Models.Dto;
using FrenetOrder.Models.Entity;
using FrenetOrder.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FrenetOrder.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContextClass _context;
        public OrderRepository(DbContextClass context)
        {
            _context = context;
        }

        public async Task<Order> GetById(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(order => order.Id == id);
            if (order == null)
            {
                throw new Exception("Pedido não encontrado!");
            }

            return order;
        }

        public async Task<List<Order>> Get()
        {
            var orderList = await _context.Orders.ToListAsync();
            if (orderList == null || orderList.Count == 0)
            {
                throw new Exception("Nenhum pedido encontrado!");
            }

            return orderList;
        }

        public async Task Update(int id, OrderUpdateInput order)
        {
            var oldOrder = await GetById(id);

            oldOrder.Origem = order.Origem;
            oldOrder.Destino = order.Destino;
            oldOrder.Status = order.Status;

            _context.Update(oldOrder);
            await _context.SaveChangesAsync();
        }

        public async Task<Order> Create(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task Remove(int id)
        {
            var order = await GetById(id);

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

    }
}
