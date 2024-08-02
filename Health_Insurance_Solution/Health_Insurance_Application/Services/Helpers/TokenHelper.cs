using Health_Insurance_Application.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Health_Insurance_Application.Services.Helpers
{
    public class TokenHelper
    {
        private string _secretKey;
        private SymmetricSecurityKey _key;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TokenHelper(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _secretKey = configuration?.GetSection("TokenKey")?.GetSection("JWT")?.Value.ToString();
            if (string.IsNullOrEmpty(_secretKey))
            {
                throw new NullReferenceException("JWt Secret Key is Null");
            }

            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            _httpContextAccessor = httpContextAccessor;
        }
        public string GenerateToken(User user)
        {
            var claim = new List<Claim>() {
                new Claim("eid", user.Uid.ToString()),
                new Claim("iat" ,  DateTimeOffset.Now.ToUnixTimeSeconds().ToString()),
                new Claim("exp" ,  DateTimeOffset.Now.AddDays(2).ToUnixTimeSeconds().ToString()),
                new Claim(ClaimTypes.Role , user.Role.ToString())
            };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
             null,
             null,
             claim,
             expires: DateTime.Now.AddDays(2),
             signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public int GetUidFromToken()
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst("eid")?.Value;
            if (userId == null)
            {
                throw new UnauthorizedAccessException("The Token is Invalid");
            }
            if (int.TryParse(userId, out int eid))
            {
                return eid;
            }
            return 0;
        }
    }
}
