using FrenetOrder.Models.Entity;
using FrenetOrder.Repository.Interface;
using FrenetOrder.Service.Interface;

namespace FrenetOrder.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> GetById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Operação não permitida, identificador não pode ser menor que zero");
            }

            return await _customerRepository.GetById(id);
        }

        public async Task<List<Customer>> Get()
        {
            return await _customerRepository.Get();
        }

        public async Task Update(int id, Customer customer)
        {
            if (id <= 0)
            {
                throw new Exception("Operação não permitida, identificador não pode ser menor que zero");
            }

            await _customerRepository.Update(id, customer);
        }

        public async Task<Customer> Create(Customer customer)
        {
            var customerResult = await _customerRepository.Create(customer);

            return customerResult;
        }

    }
}
