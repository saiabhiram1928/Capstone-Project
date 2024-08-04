using Health_Insurance_Application.DTO;
using Health_Insurance_Application.Models;
using Health_Insurance_Application.Models.Enums;
using Health_Insurance_Application.Repositories.Interfaces;
using Health_Insurance_Application.Services.Helpers;
using Health_Insurance_Application.Services.Interfaces;

namespace Health_Insurance_Application.Services
{
    public class UserServices : IUserService
    {
        private ICustomerRepository _customerRepo;
        private IUserRepository _userRepo;
        private readonly TokenHelper _tokenHelper;
        private readonly IPaymentRepository _paymentRepo;
        private readonly IPolicyRepository _policyRepo;
        private readonly IClaimRepository _claimRepo;

        public UserServices(ICustomerRepository customerRepository , IUserRepository  userRepository , IConfiguration configuration, IHttpContextAccessor httpContextAccessor , IPaymentRepository paymentRepository , IPolicyRepository policyRepository , IClaimRepository claimRepository) 
        {
            _customerRepo = customerRepository;
            _userRepo = userRepository;
            _tokenHelper = new TokenHelper(configuration, httpContextAccessor);
            _paymentRepo = paymentRepository;
            _policyRepo = policyRepository;
            _claimRepo = claimRepository;
        }

        public async Task<MessageDTO> EditProfile(ProfileDTO profileDTO) 
        {
          
            int uid = _tokenHelper.GetUidFromToken();
            bool checkUserCustomer = await _customerRepo.CheckUserExistByUid(uid);
            var user = await _userRepo.GetById(uid);
            user.Address = profileDTO.Address;
            user.FirstName = profileDTO.FirstName;
            user.LastName = profileDTO.LastName;
            user.Zipcode = profileDTO.Zipcode;
            user.LastUpdated = DateTime.Now;
            user.DateOfBirth = profileDTO.DateOfBirth;
            if (Enum.TryParse<GenderEnum>(profileDTO.Gender, out var genderEnum))
            {
                user.Gender = genderEnum;
            }
            await _userRepo.Update(user);
            return new MessageDTO()
            {
                Message = "User Updated sucessfully"
            };
            
        }

        public async Task<ProfileDTO> GetProfile()
        {
            int uid = _tokenHelper.GetUidFromToken();
            var user = await _userRepo.GetById(uid);
            ProfileDTO profileDTO = new ProfileDTO();
            profileDTO.DateOfBirth = user.DateOfBirth;
            profileDTO.Gender = user.Gender.ToString();
            profileDTO.Zipcode = user.Zipcode;
            profileDTO.FirstName = user.FirstName;
            profileDTO.LastName = user.LastName;
            profileDTO.Address = user.Address;
            profileDTO.CreatedAt = user.CreatedAt;
            profileDTO.LastUpdatedAt = user.LastUpdated;
            profileDTO.MobileNumber = user.MobileNumber;
            profileDTO.Email = user.Email;
            return profileDTO;
        }

        public async Task<IList<NotificationDTO>> GetNofitications()
        {
            int uid = _tokenHelper.GetUidFromToken();
            var customer = await _customerRepo.GetByUid(uid);   
            var duePayment  =await  _paymentRepo.GetPaymentExpriring(customer.CustomerId);
            var recentCreatedpolicy = await  _policyRepo.GetRecentCreatedPolicy(customer.CustomerId);
            var recenetPayment = await _paymentRepo.GetRecentPayment(customer.CustomerId);
            var recentClaim =await _claimRepo.GetRecentClaim(customer.CustomerId);
            var notificationDTOs = new List<NotificationDTO>();   
            if(duePayment !=  null)
            {
                NotificationDTO notificationDTO = new NotificationDTO()
                {
                    CreatedAt = DateTime.UtcNow,
                    Message = $"You Have Due Payment of {duePayment.PaymentAmount} , of Due Date {duePayment.PaymentDueDate.ToString("dd/MM/yyyy")}"
                };
                notificationDTOs.Add(notificationDTO);
            }
            if(recentCreatedpolicy != null)
            {
                NotificationDTO notificationDTO = new NotificationDTO()
                {
                    CreatedAt = recentCreatedpolicy.PolicyStartDate,
                    Message = $"You Have Created a Policy on {recentCreatedpolicy.PolicyStartDate.ToString("dd/MM/yyyy")}"
                };
                notificationDTOs.Add(notificationDTO);
            }
            if(recenetPayment != null)
            {

                NotificationDTO notificationDTO = new NotificationDTO()
                {
                    CreatedAt = recenetPayment.PaymentDate,
                    Message = $"We Have Sucessfully Recived Payment of {recenetPayment.PaymentAmount} on {recenetPayment.PaymentDate.ToString("dd/MM/yyyy")} for Policy Id {recenetPayment.PolicyId}"
                };
                notificationDTOs.Add(notificationDTO);
            }
            if(recentClaim != null)
            {
                NotificationDTO notificationDTO = new NotificationDTO()
                {
                    CreatedAt = recentClaim.ClaimedDate,
                    Message = $"The Claim Status of Rs {recentClaim.AmountClaimed} is {recentClaim.ClaimStatus}"
                };
                notificationDTOs.Add(notificationDTO);
            }
            return notificationDTOs.OrderByDescending(item => item.CreatedAt).ToList();
        }

    }
}
