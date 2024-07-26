using Health_Insurance_Application.Models;

namespace Health_Insurance_Application.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<int , User>
    {
        public Task<User> GetUserByPhoneOrEmail(string key);
        public Task<bool> CheckUserExist(string email ,string phone);
    }
}
