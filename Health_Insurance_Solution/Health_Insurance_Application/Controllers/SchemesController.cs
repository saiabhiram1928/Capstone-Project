using Health_Insurance_Application.DTO;
using Health_Insurance_Application.Exceptions;
using Health_Insurance_Application.Services;
using Health_Insurance_Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace Health_Insurance_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchemesController : ControllerBase
    {
        private ISchemeServices _schemeService;

        public SchemesController(ISchemeServices schemeServices)
        {
            _schemeService = schemeServices;
        }

        [HttpGet("CalPremium")]

        public async Task<IActionResult> Login([FromBody] PremiumCalDTO premiumCalDTO , [FromQuery] string payload )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(payload == null)
            {
                return BadRequest(new ErrorDTO() { Code = 409, Message = "Payload Cant be Empty" });
            }
            try
            {
                if (payload == "Normal")
                {
                    var res = await _schemeService.CalculatePremiumForTotal(premiumCalDTO.PaymentFrequency, premiumCalDTO.SchemeId);
                    return Ok(res);
                } else if (payload == "Quoted")
                {
                    var res = await _schemeService.CalculatePremiumWithQuote(premiumCalDTO.PaymentFrequency, premiumCalDTO.SchemeId, premiumCalDTO.QuotedCoverageAmount, premiumCalDTO.QuotedPaymentTerm);
                }
                return BadRequest(new ErrorDTO() { Code = 400, Message = "Please Check Premium Type" });

            }
            catch (NoSuchItemInDbException ex)
            {
                return NotFound(new ErrorDTO() { Code = 404, Message = ex.Message });
            } catch (NotSupportedException ex)
            {
                return BadRequest(new ErrorDTO() { Code = 400, Message = ex.Message });
            }
            catch (DbException ex)
            {
                return StatusCode(500, new ErrorDTO() { Code = 500, Message = "A database error occurred. Please try again." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorDTO {Code =500, Message = ex.Message });
            }
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAll([FromQuery] string payload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (payload == null)
            {
                return BadRequest(new ErrorDTO() { Code = 409, Message = "Payload Cant be Empty" });
            }
            try
            {
                if(payload == "routes")
                {
                    var res = await _schemeService.GetAllSchemeRoutes();
                    return Ok(res);
                }
                return BadRequest(new ErrorDTO() { Code = 400 , Message = "Please Check payload" });
                
            }catch(Exception ex)
            {
                return StatusCode(500, new ErrorDTO() {Code= 500, Message = ex.Message });
            }
        }
    }
}
