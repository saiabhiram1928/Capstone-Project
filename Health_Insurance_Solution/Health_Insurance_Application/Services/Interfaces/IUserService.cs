using Health_Insurance_Application.DTO;

namespace Health_Insurance_Application.Services.Interfaces
{
    public interface IUserService
    {
        public  Task<ProfileDTO> GetProfile();
        public Task<MessageDTO> EditProfile(ProfileDTO profileDTO);
        public Task<IList<NotificationDTO>> GetNofitications();
    }
}
