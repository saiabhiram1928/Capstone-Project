using Health_Insurance_Application.DTO;
using Health_Insurance_Application.Models;
using Health_Insurance_Application.Models.Enums;
using Health_Insurance_Application.Services.Interfaces;

namespace Health_Insurance_Application.Services
{
    public class DTOService : IDTOService
    {
        public UserReturnDTO MapUserToUserReturnDTO(User user, string Token)
        {
           UserReturnDTO  userReturnDTO = new UserReturnDTO();
            userReturnDTO.Token = Token;
            userReturnDTO.FirstName = user.FirstName;
            userReturnDTO.LastName = user.LastName;
            userReturnDTO.Role = user.Role.ToString();
            return userReturnDTO;
        }

        public User MapUserRegisterDTOToUser(UserRegisterDTO userRegisterDTO,string role, byte[] salt, byte[] passwd)
        {
            RoleEnum roleEnum = (RoleEnum)Enum.Parse(typeof(RoleEnum), role);
            User user = new User();
            user.FirstName = userRegisterDTO.FirstName;
            user.LastName = userRegisterDTO.LastName;
            user.Zipcode = userRegisterDTO.Zipcode;
            user.Email = userRegisterDTO.Email;
            user.Role = roleEnum;
            user.Address = userRegisterDTO.Address;
            user.MobileNumber = userRegisterDTO.MobileNumber;
            user.LastUpdated = DateTime.Now;
            user.CreatedAt =DateTime.Now;
            user.Salt = salt;
            user.Password  = passwd;
            return user;
            
        }

        public SchemeRoutesDTO MapSchemeToSchemeRouteDTO(Scheme scheme)
        {
            SchemeRoutesDTO schemeRoutesDTO = new SchemeRoutesDTO();
            schemeRoutesDTO.SchemeName = scheme.SchemeName;
            schemeRoutesDTO.SchemeRoute = scheme.RouteTitle;
            schemeRoutesDTO.SchemeType = scheme.SchemeType.ToString();
            schemeRoutesDTO.SmallDesc = scheme.SmallDescription;
            return schemeRoutesDTO;

        }
    }
}
