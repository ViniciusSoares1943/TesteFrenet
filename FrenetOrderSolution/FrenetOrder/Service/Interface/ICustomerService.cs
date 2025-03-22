using FrenetOrder.Models.Dto;
using FrenetOrder.Models.Entity;

namespace FrenetOrder.Service.Interface
{
    public interface ICustomerService
    {
        public Task<Customer> GetById(int id);
        public Task<List<Customer>> Get();
        public Task Update(int id, CustomerInput customer);
        public Task<Customer> Create(CustomerInput customer);
        public Task Remove(int id);
    }
}
