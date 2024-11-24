using AutoMapper;
using CustomerOrderManagement.Models.APIModels.Customer;
using CustomerOrderManagement.Models.EntityModels;
using CustomerOrderManagement.Service.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        IMapper _mapper;
        public CustomerController(ICustomerService customerService,IMapper mapper)
        {
            _customerService = customerService;
            _mapper=mapper;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery]CustomerSearchDTO customerSearchDTO)
        {
            var customers = _customerService.GetAll(customerSearchDTO);
            return Ok(customers);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerCreateDTO customerCreateDTO)
        {
            var customer2=_mapper.Map<Customer>(customerCreateDTO);
            /*var customer = new Customer
            {
                Address= customerCreateDTO.Address,
                Name= customerCreateDTO.Name,
                PhoneNo= customerCreateDTO.PhoneNo,
                CategoryId=customerCreateDTO.CategoryId
            };*/
            var res = await _customerService.AddAsync(customer2);
            return Ok(res>0?"Customer Added Successfully":"Customer Add Failed");
        }
    }
}
