using Health_Insurance_Application.Context;
using Health_Insurance_Application.Models;
using Health_Insurance_Application.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;

namespace Health_Insurance_Application.Repositories
{
    public class UserRepostiory : CRUDRepository<int, User>, IUserRepository
    {
       public UserRepostiory(HealthInsuranceContext context) : base(context) { }

        public async Task<User> GetUserByPhoneOrEmail(string key)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(item => (item.Email == key || item.MobileNumber == key));
                return user;
            }
            catch (DbException dbEx)
            {
                Console.WriteLine($"Database error: {dbEx}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex}");
                throw;
            }
        }
        public async Task<bool> CheckUserExist(string email , string phone)
        {
            try
            {
                var item = await _context.Users.AnyAsync(item => (item.Email == email || item.MobileNumber == phone));
                return item;
            }
            catch (DbException dbEx)
            {
                Console.WriteLine($"Database error: {dbEx}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex}");
                throw;
            }
        }

    }
}
