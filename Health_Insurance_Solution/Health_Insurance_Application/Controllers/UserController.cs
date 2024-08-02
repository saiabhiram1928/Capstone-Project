using Health_Insurance_Application.DTO;
using Health_Insurance_Application.Exceptions;
using Health_Insurance_Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;

namespace Health_Insurance_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService) { 
            _userService = userService;
        }
        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            try{
                var res =await _userService.GetProfile();
                return Ok(res);
            }
            catch (NoSuchItemInDbException ex)
            {
                return NotFound(new ErrorDTO(404, ex.Message));
            }catch(UnauthorizedAccessException ex)
            {
                return Unauthorized(new ErrorDTO(401,ex.Message));
            }
            catch (DbException ex)
            {
                return StatusCode(500, new ErrorDTO(500, "A database error occurred. Please try again."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [Authorize]
        [HttpPost("update")]
        public async Task<IActionResult> UpdateProfile([FromBody]ProfileDTO profileDTO)
        {
            try
            {
                var res = await _userService.EditProfile(profileDTO);
                return Ok(res);
            }
            catch (NoSuchItemInDbException ex)
            {
                return NotFound(new ErrorDTO(404, ex.Message));
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new ErrorDTO(401, ex.Message));
            }
            catch (DbException ex)
            {
                return StatusCode(500, new ErrorDTO(500, "A database error occurred. Please try again."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Customer")]
        [HttpGet("notify")]
        public async Task<IActionResult> GetNotifications()
        {
            try
            {
                var res = await _userService.GetNofitications();
                return Ok(res);
            }
            catch (NoSuchItemInDbException ex)
            {
                return NotFound(new ErrorDTO(404, ex.Message));
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new ErrorDTO(401, ex.Message));
            }
            catch (DbException ex)
            {
                return StatusCode(500, new ErrorDTO(500, "A database error occurred. Please try again."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


    }
}
