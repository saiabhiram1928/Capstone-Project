using Health_Insurance_Application.DTO;
using Health_Insurance_Application.Exceptions;
using Health_Insurance_Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace Health_Insurance_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private IUserAuthService _userAuthService;

        public UserAuthController(IUserAuthService userAuthService) 
        {
            _userAuthService = userAuthService;
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(UserReturnDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO registerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _userAuthService.Register(registerDTO);
                return Ok(result);
            }
            catch (DuplicateItemException ex)
            {
                return Conflict(new ErrorDTO() { Code = 409 , Message =ex.Message });
            }catch(DbException ex)
            {
                return StatusCode(500, new ErrorDTO() { Code = 500, Message = "A database error occurred. Please try again." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("createUser")]
        [ProducesResponseType(typeof(UserReturnDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> createUser([FromBody] UserRegisterDTO registerDTO , [FromQuery] string destRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _userAuthService.RegisterWithRole(registerDTO , destRole);
                return Ok(result);
            }
            catch (DuplicateItemException ex)
            {
                return Conflict(new ErrorDTO() { Code = 409 , Message =ex.Message });
            }catch(DbException ex)
            {
                return StatusCode(500, new ErrorDTO() { Code = 500, Message = "A database error occurred. Please try again." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [HttpPost("login")]
        [ProducesResponseType(typeof(UserReturnDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _userAuthService.Login(userLoginDTO);
                return Ok(result);
            }
            catch (DuplicateItemException ex)
            {
                return Conflict(new ErrorDTO() { Code = 409, Message = ex.Message });
            }
            catch (DbException ex)
            {
                return StatusCode(500, new ErrorDTO() { Code = 500, Message = "A database error occurred. Please try again." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

    }
}
