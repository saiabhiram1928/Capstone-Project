using Health_Insurance_Application.DTO;
using Health_Insurance_Application.Exceptions;
using Health_Insurance_Application.Models;
using Health_Insurance_Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Health_Insurance_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private IPolicyService _policyService;

        public PolicyController(IPolicyService policyService)
        {
            _policyService = policyService;
        }
        [Authorize(Roles = "Customer")]
        [HttpPost("apply")]
        [ProducesResponseType(typeof(PolicyReturnDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> ApplyPolicy(PolicyApplyDTO policyApplyDTO)
        {
            try
            {
                var res = await _policyService.AddPolicy(policyApplyDTO);
                return Ok(res);
            }catch(DuplicateItemException ex)
            {
                return Conflict(new ErrorDTO(409, ex.Message));
            }
            catch(NoSuchItemInDbException ex)
            {
                return NotFound(new ErrorDTO(404, ex.Message));
            }catch(UnauthorizedAccessException ex)
            {
                return Unauthorized(new ErrorDTO(401, ex.Message));
            }catch(NotSupportedException ex)
            {
                return BadRequest(new ErrorDTO(400, ex.Message));
            }catch(Exception ex)
            {
                return StatusCode(500,new ErrorDTO(500, ex.Message));
            }
        }
         [Authorize(Roles = "Customer")]
        [HttpPost("apply-renewal")]
        [ProducesResponseType(typeof(PolicyReturnDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> ApplyRenewal(int policyId)
        {
            try
            {
                var res = await _policyService.RenewalPolicy(policyId);
                return Ok(res);
            }catch(DuplicateItemException ex)
            {
                return Conflict(new ErrorDTO(409, ex.Message));
            }
            catch(NoSuchItemInDbException ex)
            {
                return NotFound(new ErrorDTO(404, ex.Message));
            }catch(UnauthorizedAccessException ex)
            {
                return Unauthorized(new ErrorDTO(401, ex.Message));
            }catch(NotSupportedException ex)
            {
                return BadRequest(new ErrorDTO(400, ex.Message));
            }catch(Exception ex)
            {
                return StatusCode(500,new ErrorDTO(500, ex.Message));
            }
        }

        [Authorize(Roles = "Customer")]
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(IList<PolicyReturnDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> FetchAllPolicies()
        {
            try
            {
                var res = await _policyService.FetchPolices();
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
            catch (NotSupportedException ex)
            {
                return BadRequest(new ErrorDTO(400, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorDTO(500, ex.Message));
            }
        }
        [Authorize(Roles = "Customer")]
        [HttpPost("add-claim")]
        [ProducesResponseType(typeof(IList<PolicyReturnDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ApplyClaim([FromBody] ClaimApplyDTO claimApplyDTO )
        {
            try
            {
                var res = await _policyService.ApplyClaim(claimApplyDTO.ClaimAmount, claimApplyDTO.ClaimReason, claimApplyDTO.PolicyId , claimApplyDTO.SchemeId);
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
            catch (NotSupportedException ex)
            {
                return BadRequest(new ErrorDTO(400, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorDTO(500, ex.Message));
            }
        }
        [Authorize(Roles = "Customer")]
        [HttpGet("get-payments")]
        [ProducesResponseType(typeof(IList<Payment>), StatusCodes.Status200OK)]
        public async  Task<IActionResult> GetAllPayments()
        {
            try
            {
               var res = await _policyService.GetAllPayment();
                return Ok(res);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new ErrorDTO(401, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorDTO(500, ex.Message));
            }
        } 
        [Authorize(Roles = "Customer")]
        [HttpPut("premium-pay")]
        [ProducesResponseType(typeof(IList<Payment>), StatusCodes.Status200OK)]
        public async  Task<IActionResult> GetAllPayments([FromQuery] int paymentId)
        {
            try
            {
               var res = await _policyService.PremiumPayment(paymentId);
                return Ok(res);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new ErrorDTO(401, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorDTO(500, ex.Message));
            }
        }



    }
}
