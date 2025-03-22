using FrenetOrder.Models.Dto;
using FrenetOrder.Models.Entity;

namespace FrenetOrder.Repository.Interface
{
    public interface ICustomerRepository
    {
        public Task<Customer> GetById(int id);
        public Task<List<Customer>> Get();
        public Task Update(int id, CustomerInput customer);
        public Task<Customer> Create(CustomerInput customer);
        public Task Remove(int id);
    }
}
