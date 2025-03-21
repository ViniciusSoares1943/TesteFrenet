using FrenetOrder.Models.Entity;

namespace FrenetOrder.Service.Interface
{
    public interface ICustomerService
    {
        public Task<Customer> GetById(int id);
        public Task<List<Customer>> Get();
        public Task Update(int id, Customer customer);
        public Task<Customer> Create(Customer customer);
    }
}
