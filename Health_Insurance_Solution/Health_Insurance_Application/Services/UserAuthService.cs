using Health_Insurance_Application.DTO;
using Health_Insurance_Application.Exceptions;
using Health_Insurance_Application.Models;
using Health_Insurance_Application.Repositories.Interfaces;
using Health_Insurance_Application.Services.Helpers;
using Health_Insurance_Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Health_Insurance_Application.Services
{
    public class UserAuthService : IUserAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IAdminRepository _adminRepo;
        private readonly IHospitalAgentRepository _hospitalAgentRepo;
        private readonly IDTOService _dtoService;
        private readonly TokenHelper _tokenHelper;
        private readonly HashHelper _hashService = new HashHelper();
       

        public UserAuthService(IUserRepository userRepository, ICustomerRepository  customerRepository, IAdminRepository adminRepository , IHospitalAgentRepository hospitalAgentRepository , IDTOService dTOService , IConfiguration configuration, IHttpContextAccessor httpContextAccessor) 
        {
            _userRepo = userRepository;
            _customerRepo = customerRepository;
            _adminRepo = adminRepository;
            _hospitalAgentRepo = hospitalAgentRepository;
            _dtoService = dTOService;
            _tokenHelper = new TokenHelper(configuration, httpContextAccessor);
        }
        public async Task<UserReturnDTO> Login(UserLoginDTO loginDTO)
        {
            var user = await _userRepo.GetUserByPhoneOrEmail(loginDTO.Username);
            if(user == null)
            {
                throw new NoSuchItemInDbException("User Doenst Exist");
            }
            bool ComparePasswd = _hashService.AuthenticatePassword(loginDTO.Password, user.Salt, user.Password);
            if (!ComparePasswd)
            {
                throw new UnauthorizedAccessException("UserName Or Password Not Matching");
            }
            var Token = _tokenHelper.GenerateToken(user);
           return _dtoService.MapUserToUserReturnDTO(user, Token);
        }

        public async Task<UserReturnDTO> Register(UserRegisterDTO registerDTO )
        {
            var check = await _userRepo.CheckUserExist(registerDTO.Email, registerDTO.MobileNumber);
            if (check)
            {
                throw new DuplicateItemException("User already exists with given phone Number or Email, please try to login.");
            }

            var (passwd, salt) = _hashService.HashPasswd(registerDTO.Password);
            var user = _dtoService.MapUserRegisterDTOToUser(registerDTO, "Customer", salt, passwd);
            user = await _userRepo.Add(user);

            Customer customer = new Customer
            {
                
                EmergenceyContact = registerDTO.EmergenceyContact,
                Uid = user.Uid
            };
            await _customerRepo.Add(customer);

            var token = _tokenHelper.GenerateToken(user);

            return _dtoService.MapUserToUserReturnDTO(user ,token);
        }
        public async Task<UserReturnDTO> RegisterWithRole(UserRegisterDTO registerDTO, string destRole)
        {
          
            var check = await _userRepo.CheckUserExist(registerDTO.Email, registerDTO.MobileNumber);
            if (check)
            {
                throw new DuplicateItemException("User already exists, please try to login.");
            }

            var (passwd, salt) = _hashService.HashPasswd(registerDTO.Password);
            var user = _dtoService.MapUserRegisterDTOToUser(registerDTO, destRole, salt, passwd);
            user = await _userRepo.Add(user);

            if (destRole == "Customer")
            {
                Customer customer = new Customer
                {
                    EmergenceyContact = registerDTO.EmergenceyContact,
                    Uid = user.Uid
                };
                await _customerRepo.Add(customer);
            }
            else if (destRole == "Agent")
            {
                HospitalAgent agent = new HospitalAgent
                {
                    AgentContact = registerDTO.AgentContact,
                    HosiptalId = registerDTO.HosiptalId,
                    Uid = user.Uid
                };
                await _hospitalAgentRepo.Add(agent);
            }
            var token = _tokenHelper.GenerateToken(user);
            return _dtoService.MapUserToUserReturnDTO(user , token);
        }

    }
}
