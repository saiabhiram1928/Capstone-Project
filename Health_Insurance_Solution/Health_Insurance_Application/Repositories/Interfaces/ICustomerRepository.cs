using Health_Insurance_Application.Models;

namespace Health_Insurance_Application.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepository<int, Customer>
    {
        public Task<Customer> GetByUid(int uid);
        public Task<bool> CheckUserExistByUid(int uid);
        public Task<User> GetUserFromCustomerId(int customerId);
    }
}
