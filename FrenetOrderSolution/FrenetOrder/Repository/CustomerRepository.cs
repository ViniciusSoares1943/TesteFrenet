using FrenetOrder.Data;
using FrenetOrder.Models.Entity;
using FrenetOrder.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FrenetOrder.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DbContextClass _context;
        public CustomerRepository(DbContextClass context)
        {
            _context = context;
        }

        public async Task<Customer> GetById(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(customer => customer.Id == id);
            if (customer == null)
            {
                throw new Exception("Cliente não encontrado!");
            }

            return customer;
        }

        public async Task<List<Customer>> Get()
        {
            var customerList = await _context.Customers.ToListAsync();
            if (customerList == null || customerList.Count == 0)
            {
                throw new Exception("Nenhum cliente encontrado!");
            }

            return customerList;
        }

        public async Task Update(int id, Customer customer)
        {
            var oldCustomer = await GetById(id);
            
            oldCustomer.Nome = customer.Nome;
            oldCustomer.Endereco = customer.Endereco;
            oldCustomer.Telefone = customer.Telefone;
            oldCustomer.Email = customer.Email;

            _context.Update(oldCustomer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> Create(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }


    }
}
