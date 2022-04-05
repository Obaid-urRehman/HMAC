using HMACAuthenticationDotNet5.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HMACAuthenticationDotNet5.Controllers
{
    [Authorize(AuthenticationSchemes = "HMAC")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("Register")]
        public IActionResult RegisterCustomer(string name, string identificationNo)
        {
            return Ok(_customerService.RegisterCustomer(name, identificationNo));
        }

        [HttpGet("IsExist")]
        public IActionResult IsCustomerExist(string identificationNo)
        {
            return Ok(_customerService.IsExist(identificationNo));
        }
    }
}
