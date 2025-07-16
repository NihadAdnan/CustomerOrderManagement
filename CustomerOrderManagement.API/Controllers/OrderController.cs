using CustomerOrderManagement.Models.APIModels.Order;
using CustomerOrderManagement.Service.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]
        public async Task<IActionResult>PayNow(OrderCreateDTO orderCreateDTO)
        {
            var response=await _orderService.PayNow(orderCreateDTO);  
            return Ok(response);
        }
    }
}
