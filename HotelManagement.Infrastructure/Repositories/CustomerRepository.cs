using HotelManagement.Core.Entities;
using HotelManagement.Core.RepositoryInterfaces;
using HotelManagement.Core.ServiceInterfaces;
using HotelManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Infrastructure.Repositories
{
    public class CustomerRepository : EfRepository<Customer>, ICustomerRepository
    {


        public CustomerRepository(HotelManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var customers = await _dbContext.Customers.ToListAsync();
            return customers;
        }

        public override async Task<Customer> GetByIdAsync(int id)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null) return null;
            return customer;
        }
    }
}
