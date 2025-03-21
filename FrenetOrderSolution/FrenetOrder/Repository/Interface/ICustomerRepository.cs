using FrenetOrder.Models.Entity;

namespace FrenetOrder.Repository.Interface
{
    public interface ICustomerRepository
    {
        public Task<Customer> GetById(int id);
        public Task<List<Customer>> Get();
        public Task Update(int id, Customer customer);
        public Task<Customer> Create(Customer customer);
    }
}
