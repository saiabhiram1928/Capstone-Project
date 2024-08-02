using Health_Insurance_Application.DTO;
using Health_Insurance_Application.Exceptions;
using Health_Insurance_Application.Models;
using Health_Insurance_Application.Models.Enums;
using Health_Insurance_Application.Repositories.Interfaces;
using Health_Insurance_Application.Services.Helpers;
using Health_Insurance_Application.Services.Interfaces;
using System.Transactions;

namespace Health_Insurance_Application.Services
{
    public class PolicyServices : IPolicyService
    {
        private readonly IPolicyRepository _policyRepo;
        private readonly ISchemeServices _schemeService;
        private readonly ISchemeRepository _schemeRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IPaymentRepository _paymentRepo;
        private readonly TokenHelper _tokenHelper;
        private readonly ICorporateEmployeeRepository _corporateEmployeeRepo;
        private readonly IFamilyMemberRepository _familyMemberRepo;
        private readonly IClaimRepository _claimRepo;
        private readonly IRenewalRepository _renewalRepo;

        public PolicyServices(IPolicyRepository policyRepository , ISchemeServices schemeServices , ISchemeRepository schemeRepository , ICustomerRepository customerRepository , IPaymentRepository paymentRepository , IConfiguration configuration, IHttpContextAccessor httpContextAccessor,ICorporateEmployeeRepository corporateEmployeeRepository ,IFamilyMemberRepository familyMemberRepository, IClaimRepository claimRepository, IRenewalRepository renewalRepository)
        { 
            _policyRepo = policyRepository;
            _schemeService = schemeServices;
            _schemeRepo = schemeRepository;
            _customerRepo = customerRepository; 
            _paymentRepo = paymentRepository;
            _tokenHelper = new TokenHelper(configuration, httpContextAccessor);
            _corporateEmployeeRepo = corporateEmployeeRepository;
            _familyMemberRepo = familyMemberRepository;
            _claimRepo = claimRepository;
            _renewalRepo = renewalRepository;
        }
        public async Task<MessageDTO> AddPolicy(PolicyApplyDTO policyApplyDTO)
        {
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var scheme = await _schemeRepo.GetById(policyApplyDTO.schemeId);
                    var check = await _policyRepo.CheckUserAppliedForPolicy(policyApplyDTO.schemeId);
                    if (check)
                    {
                        throw new DuplicateItemException("You Have Already Applied for the Policy");
                    }
                    int uid = _tokenHelper.GetUidFromToken();
                    var customer = await _customerRepo.GetByUid(uid);
                    PremiumReturnDTO premiumReturnDTO = null;

                    if (policyApplyDTO.Opt == "normal")
                    {
                        premiumReturnDTO = await _schemeService.CalculatePremiumForTotal(policyApplyDTO.PaymentFrequency, policyApplyDTO.schemeId);
                    }
                    else
                    {
                        premiumReturnDTO = await _schemeService.CalculatePremiumWithQuote(policyApplyDTO.PaymentFrequency, policyApplyDTO.schemeId, policyApplyDTO.CoverageAmount, policyApplyDTO.PaymentTerm);
                    }

                    int paymentFreq = policyApplyDTO.PaymentFrequency switch
                    {
                        "Quarterly" => 3,
                        "Annually" => 1,
                        _ => 12, 
                    };

                    var policy = new Policy()
                    {
                        CustomerId = customer.CustomerId,
                        PaymentFrequency = (PaymentFrequencyEnum)Enum.Parse(typeof(PaymentFrequencyEnum), policyApplyDTO.PaymentFrequency),
                        QuoteAmount = policyApplyDTO.CoverageAmount,
                        PolicyStartDate = DateTime.Now,
                        PremiumAmount = premiumReturnDTO.Premium,
                        PolicyExpiryDate = DateTime.Now.AddYears(premiumReturnDTO.CalCoverageYears),
                        QuotePaymentTerm = policyApplyDTO.PaymentTerm,
                        RenewalStatus = RenewalStatusEnum.Pending,
                        SchemeId = policyApplyDTO.schemeId,
                        PolicyEndDate = DateTime.Now.AddYears(premiumReturnDTO.CalCoverageYears),
                        NextPaymentDueDate = DateTime.Now.AddMonths(12 / paymentFreq),
                        CoverageYears = premiumReturnDTO.CalCoverageYears,
                    };

                    policy = await _policyRepo.Add(policy);

                    Payment basePremiumAmount = new Payment()
                    {
                        CustomerId = customer.CustomerId,
                        PaymentDone = false,
                        PaymentAmount = scheme.BasePremiumAmount,
                        PaymentDueDate = DateTime.Now.AddDays(2),
                        PaymentType = PaymentTypeEnum.Premium,
                        Remarks = "Base Premium Amount",
                        PaymentStatus = "Pending",
                        PolicyId = policy.PolicyId,
                    };

                    await _paymentRepo.Add(basePremiumAmount);

                    for (int i = 0; i < (policyApplyDTO.PaymentTerm * paymentFreq); i++)
                    {
                        int time = 12 / paymentFreq;
                        Payment payment = new Payment()
                        {
                            CustomerId = customer.CustomerId,
                            PaymentAmount = premiumReturnDTO.Premium,
                            PaymentDone = false,
                            PaymentDueDate = DateTime.Now.AddMonths(time * (i + 1)),
                            PaymentStatus = "Pending",
                            PolicyId = policy.PolicyId,
                            Remarks = "Payment Need to be Completed",
                            PaymentType = PaymentTypeEnum.Premium
                        };
                        await _paymentRepo.Add(payment);
                    }
                    if(scheme.SchemeType == SchemeTypeEnum.Family)
                    {
                        for(int i =0;i <policyApplyDTO.FamilyMembers.Count;i++)
                        {
                            var familyMem = new FamilyMember()
                            {
                                AadharId = policyApplyDTO.FamilyMembers[i].AdharId,
                                Name = policyApplyDTO.FamilyMembers[i].Name,
                                PolicyId = policy.PolicyId
                            };
                            await _familyMemberRepo.Add(familyMem);
                        }
                    }else if(scheme.SchemeType == SchemeTypeEnum.Corporate)
                    {
                        for(int i =0;i< policyApplyDTO.CorporateMembers.Count; i++)
                        {
                            var corporateEmp = new CorporateEmployee()
                            {
                                EmployeeId = policyApplyDTO.CorporateMembers[i].EmpId,
                                PolicyId = policy.PolicyId,
                                EmployeeName = policyApplyDTO.CorporateMembers[i].Name
                            };
                            await _corporateEmployeeRepo.Add(corporateEmp);
                        }
                    }
                    transaction.Complete();
                    return new MessageDTO
                    {
                        Message = $"{policy.PolicyId}",
                    };
                }
            }catch(NoSuchItemInDbException ex)
            {
                throw;
            }catch(UnauthorizedAccessException ex)
            {
                throw;
            }catch(NotSupportedException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<IList<PolicyReturnDTO>> FetchPolices()
        {
            int uid = _tokenHelper.GetUidFromToken();
            var customer = await _customerRepo.GetByUid(uid);
            var policies =await _policyRepo.GetAllPoliciesAsync(customer.CustomerId);
            var policyReturnDTOs = new List<PolicyReturnDTO>();
            foreach(var pol in policies)
            {
                var policyReturnDTO = new PolicyReturnDTO()
                {
                    PolicyId = pol.PolicyId,
                    Payments = pol.Payments.Where(p => p.PaymentDone == true).ToList(),
                    CorporateEmployees = pol.CorporateEmployees.ToList(),
                    Claims = pol.Claims.ToList(),
                    FamilyMembers = pol.FamilyMembers.ToList(),
                    LastPaymentDate = pol.LastPaymentDate,
                    NextPaymentDueDate = pol.NextPaymentDueDate,
                    PolicyEndDate = pol.PolicyEndDate,
                    policyExpiryDate = pol.PolicyExpiryDate,
                    PolicyStartDate = pol.PolicyStartDate,
                    PremiumAmount = pol.PremiumAmount,
                    QuoteAmount = pol.QuoteAmount,
                    RenewalStatus = pol.RenewalStatus.ToString(),
                    Scheme = pol.Scheme,
                    Renewals = pol.Renewals.ToList()
                };
                policyReturnDTOs.Add(policyReturnDTO);
            }
            return policyReturnDTOs;
        }
        public async Task<MessageDTO> ApplyClaim(float ClaimAmount , string ClaimReason, int policyId , int schemeId)
        {
            int uid = _tokenHelper.GetUidFromToken();
            var customer = await _customerRepo.GetByUid(uid);
            var scheme = await _schemeRepo.GetById(schemeId);
            var policy = await _policyRepo.GetById(policyId);
            var anyPaymentDone = await _paymentRepo.CheckAnyPaymentPaid(customer.CustomerId, scheme.BasePremiumAmount);
            if(anyPaymentDone == false)
            {
                return new MessageDTO()
                {
                    Message = "Please Pay, Base Premium Amount"
                };
            }
            if(ClaimAmount > policy.QuoteAmount)
            {
                return new MessageDTO()
                {
                    Message = "You Calimed Amout is greater than your Coverage Amount"
                };
            }
            if (DateTime.Now  < policy.PolicyStartDate.AddYears(policy.QuotePaymentTerm) && ClaimAmount > scheme.BaseCoverageAmount )
            {
                return new MessageDTO()
                {
                    Message = "You are still on Payment Term, You Claim Can only be Up to base Coverage Amount"
                };
            }
            Claims claimcustomer = new Claims()
            {
                AmountClaimed = ClaimAmount,
                ClaimedDate = DateTime.Now,
                ClaimReason = ClaimReason,
                ClaimStatus = ClaimStatusEnum.UnderReview,
                PolicyId = policyId,
                CustomerId = customer.CustomerId,
            };
            await _claimRepo.Add(claimcustomer);

            return new MessageDTO()
            {
                Message = "Claim Added SucessFully"
            };

        }

        public async Task<IList<Payment>> GetAllPayment()
        {
            int uid = _tokenHelper.GetUidFromToken();
            var customer = await _customerRepo.GetByUid(uid);
            var payments = await _paymentRepo.GetAllPaymentFromCustomerd(customer.CustomerId);
            payments = payments.OrderBy(p => p.PaymentDueDate).ToList();
            return payments;
        }

        public async Task<MessageDTO> PremiumPayment(int paymentId)
        {
           var payment = await _paymentRepo.GetById(paymentId);
            payment.PaymentDate = DateTime.Now;
            payment.PaymentDone = true;
            payment.PaymentStatus = "Paid";
            payment.TransactionId = paymentId;
            await _paymentRepo.Update(payment);
            var policy = await _policyRepo.GetById(payment.PolicyId);
            var nextDate = await _paymentRepo.GetNextPaymentDueDate(payment.CustomerId);
            if(nextDate == null)
            {
                return new MessageDTO()
                {
                    Message = "You Have Completed All Payments"
                };
            }
            policy.NextPaymentDueDate = (DateTime) nextDate;
            policy.LastPaymentDate = DateTime.Now;
            await _policyRepo.Update(policy);
            return new MessageDTO()
            {
                Message = "Payment Recived Sucessfully"
            };
        }
        public async Task<MessageDTO> RenewalPolicy(int policyId)
        {
            var policy = await _policyRepo.GetById(policyId);

            if (policy.PolicyExpiryDate > DateTime.Now)
            {
                return new MessageDTO()
                {
                    Message = "You cant Renew the Policy, as it is not expired"
                };
            }

            policy = await _policyRepo.GetPolicyById(policyId);
            int uid = _tokenHelper.GetUidFromToken();
            var customer = await _customerRepo.GetByUid(uid);
            var scheme = await _schemeRepo.GetById(policy.SchemeId);

            try
            {

                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var policyApplyDTO = new PolicyApplyDTO
                    {
                        schemeId = policy.SchemeId,
                        CoverageAmount = policy.PremiumAmount,
                        PaymentTerm = policy.QuotePaymentTerm,
                        PaymentFrequency = policy.PaymentFrequency.ToString(),
                        Opt = policy.RenewalStatus.ToString(),
                        FamilyMembers = policy.FamilyMembers?.Select(fm => new FamilyMemberDTO
                        {
                            Name = fm.Name,
                            AdharId = fm.AadharId
                        }).ToList() ?? new List<FamilyMemberDTO>(),
                        CorporateMembers = policy.CorporateEmployees?.Select(ce => new CorporateMemberDTO
                        {
                            Name = ce.EmployeeName,
                            EmpId = ce.EmployeeId
                        }).ToList() ?? new List<CorporateMemberDTO>()
                    };
                    int paymentFreq = policyApplyDTO.PaymentFrequency switch
                    {
                        "Quarterly" => 3,
                        "Annually" => 1,
                        _ => 12,
                    };
                    Payment basePremiumAmount = new Payment()
                    {
                        CustomerId = customer.CustomerId,
                        PaymentDone = false,
                        PaymentAmount = scheme.BasePremiumAmount,
                        PaymentDueDate = DateTime.Now.AddDays(2),
                        PaymentType = PaymentTypeEnum.Premium,
                        Remarks = "Base Premium Amount",
                        PaymentStatus = "Pending",
                        PolicyId = policy.PolicyId,
                    };

                    var checkDiscount = await _claimRepo.CanDiscountApply(customer.CustomerId);
                    if (checkDiscount)
                    {
                        basePremiumAmount.PaymentDone = true;
                        basePremiumAmount.PaymentStatus = "Paid";
                        basePremiumAmount.Remarks = "The Base Premium amount is discounted";
                    }
                    await _paymentRepo.Add(basePremiumAmount);

                    for (int i = 0; i < (policyApplyDTO.PaymentTerm * paymentFreq); i++)
                    {
                        int time = 12 / paymentFreq;
                        Payment payment = new Payment()
                        {
                            CustomerId = customer.CustomerId,
                            PaymentAmount = policy.PremiumAmount,
                            PaymentDone = false,
                            PaymentDueDate = DateTime.Now.AddMonths(time * (i + 1)),
                            PaymentStatus = "Pending",
                            PolicyId = policy.PolicyId,
                            Remarks = "Payment Need to be Completed",
                            PaymentType = PaymentTypeEnum.Premium
                        };
                        await _paymentRepo.Add(payment);
                    }
                    if (scheme.SchemeType == SchemeTypeEnum.Family)
                    {
                        for (int i = 0; i < policyApplyDTO.FamilyMembers.Count; i++)
                        {
                            var familyMem = new FamilyMember()
                            {
                                AadharId = policyApplyDTO.FamilyMembers[i].AdharId,
                                Name = policyApplyDTO.FamilyMembers[i].Name,
                                PolicyId = policy.PolicyId
                            };
                            await _familyMemberRepo.Add(familyMem);
                        }
                    }
                    else if (scheme.SchemeType == SchemeTypeEnum.Corporate)
                    {
                        for (int i = 0; i < policyApplyDTO.CorporateMembers.Count; i++)
                        {
                            var corporateEmp = new CorporateEmployee()
                            {
                                EmployeeId = policyApplyDTO.CorporateMembers[i].EmpId,
                                PolicyId = policy.PolicyId,
                                EmployeeName = policyApplyDTO.CorporateMembers[i].Name
                            };
                            await _corporateEmployeeRepo.Add(corporateEmp);
                        }
                    }

                    Renewal renewal = new Renewal()
                    {
                        CustomerId = customer.CustomerId,
                        DiscountApplied = scheme.BasePremiumAmount,
                        NewPolicyStartDate = DateTime.Now,
                        RenewalDate = DateTime.Now,
                        PolicyId = policy.PolicyId,
                        RenewalStatus = RenewalStatusEnum.Renwed,
                    };
                    policy.RenewalStatus = RenewalStatusEnum.Renwed;
                    policy.PolicyStartDate = DateTime.Now;
                    policy.PolicyExpiryDate = DateTime.Now.AddYears(policy.CoverageYears);
                    policy.NextPaymentDueDate = DateTime.Now.AddMonths(12 / paymentFreq);
                    await _policyRepo.Update(policy);
                    await _renewalRepo.Add(renewal);
                    transaction.Complete();
                    return new MessageDTO()
                    {
                        Message = "The Policy is Renewed, Please Complete the Payments"
                    };
                }
            }
            catch (NoSuchItemInDbException ex)
            {
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                throw;
            }
            catch (NotSupportedException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        }
}
