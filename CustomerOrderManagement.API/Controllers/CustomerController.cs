using CustomerOrderManagement.Models.APIModels.Customer;
using CustomerOrderManagement.Service.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery]CustomerSearchDTO customerSearchDTO)
        {
            var customers = _customerService.GetAll(customerSearchDTO);
            return Ok(customers);
        }
    }
}
