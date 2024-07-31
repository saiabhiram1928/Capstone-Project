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


        [HttpPost("CalPremium")]

        public async Task<IActionResult> Login([FromBody] PremiumCalDTO premiumCalDTO , [FromQuery] string payload )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(payload == null)
            {
                return BadRequest(new ErrorDTO(409, "Payload Cant be Empty"));
            }
            try
            {
                if (payload == "normal")
                {
                    var res = await _schemeService.CalculatePremiumForTotal(premiumCalDTO.PaymentFrequency, premiumCalDTO.SchemeId);
                    return Ok(res);
                } else if (payload == "quote")
                {
                    var res = await _schemeService.CalculatePremiumWithQuote(premiumCalDTO.PaymentFrequency, premiumCalDTO.SchemeId, premiumCalDTO.QuotedCoverageAmount, premiumCalDTO.QuotedPaymentTerm);
                    return Ok(res);
                }
                return BadRequest(new ErrorDTO(400, "Please Check payload Type"));

            }
            catch (NoSuchItemInDbException ex)
            {
                return NotFound(new ErrorDTO(404, ex.Message));
            } catch (NotSupportedException ex)
            {
                return BadRequest(new ErrorDTO(400, ex.Message));
            }
            catch (DbException ex)
            {
                return StatusCode(500, new ErrorDTO(500, "A database error occurred. Please try again."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorDTO (500, ex.Message));
            }
        }

        [HttpGet("get")]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll([FromQuery] string payload ,[FromQuery] int? schemeId, [FromQuery] string? route)
        {
            
            if (payload == null)
            {
                return BadRequest(new ErrorDTO(409, "Payload Cant be Empty"));
            }
            try
            {
                if(payload == "routes")
                {
                    var res = await _schemeService.GetAllSchemeRoutes();
                    return Ok(res);
                }
                if(payload == "getById" )
                {
                    if(schemeId == null) return BadRequest(new ErrorDTO(400, "SchemeId cant be null"));
                    var res = await _schemeService.GetSchemeById((int) schemeId);
                    return Ok(res);
                }
                if(payload == "getByRT")
                {
                    if(route == null) return BadRequest(new ErrorDTO(400, "Route cant be null"));
                    var res = await _schemeService.GetByRouteTitle(route);
                    return Ok(res);
                }
                return BadRequest(new ErrorDTO( 400, "Please Check payload"));
            }catch(NoSuchItemInDbException ex)
            {
                return NotFound(new ErrorDTO(404, ex.Message));
            }
            
            catch(Exception ex)
            {
                return StatusCode(500, new ErrorDTO(500, ex.Message)) ;
            }
        }

    }
}
