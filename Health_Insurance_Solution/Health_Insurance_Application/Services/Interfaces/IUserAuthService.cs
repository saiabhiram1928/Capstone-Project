using Health_Insurance_Application.DTO;

namespace Health_Insurance_Application.Services.Interfaces
{
    public interface IUserAuthService
    {
        public Task<UserReturnDTO> Login(UserLoginDTO loginDTO);
        public  Task<UserReturnDTO> Register(UserRegisterDTO registerDTO);
        public Task<UserReturnDTO> RegisterWithRole(UserRegisterDTO registerDTO, string destRole);
    }
}
