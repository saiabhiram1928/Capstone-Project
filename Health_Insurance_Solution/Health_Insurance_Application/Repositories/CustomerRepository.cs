using Health_Insurance_Application.Context;
using Health_Insurance_Application.Exceptions;
using Health_Insurance_Application.Models;
using Health_Insurance_Application.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Health_Insurance_Application.Repositories
{
    public class CustomerRepository : CRUDRepository<int, Customer> , ICustomerRepository
    {
        public CustomerRepository(HealthInsuranceContext context) : base(context) { }

        public async Task<Customer> GetByUid(int uid)
        {
            var customer  = await _context.Customers.SingleOrDefaultAsync(item => item.Uid == uid);
            if (customer == null)
            {
                throw new NoSuchItemInDbException("The customer With Given Uid doesnt Exist");
            }
            return customer;

        }

        public async Task<bool> CheckUserExistByUid(int uid)
        {
            return await _context.Customers.AnyAsync(item => item.Uid == uid);
        }

        public async Task<User> GetUserFromCustomerId(int customerId)
        {
            var customer =await _context.Customers.Include(item => item.User)
                .SingleOrDefaultAsync(item => item.CustomerId == customerId);
            if(customer == null)
            {
                throw new NoSuchItemInDbException($"The Customer With {customerId} doesnt exist");
            }
            return customer.User;
        }
    }
}
