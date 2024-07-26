using Health_Insurance_Application.DTO;
using Health_Insurance_Application.Models;

namespace Health_Insurance_Application.Services.Interfaces
{
    public interface IDTOService
    {
        public UserReturnDTO MapUserToUserReturnDTO(User user , string Token);
        public User MapUserRegisterDTOToUser(UserRegisterDTO userRegisterDTO, string role, byte[] salt, byte[] passwd);
    }
}
