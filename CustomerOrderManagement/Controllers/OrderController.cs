using CustomerOrderManagement.Models.EntityModels;
using CustomerOrderManagement.Models.ViewModels.Customers;
using CustomerOrderManagement.Models.ViewModels.Order;
using CustomerOrderManagement.Models.ViewModels.Products;
using CustomerOrderManagement.Service.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderManagement.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;

        public OrderController(IOrderService orderService, ICustomerService customerService,IProductService productService)
        {
            _orderService = orderService;
            _customerService = customerService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var orderList = await _orderService.GetAllAsync();
            ViewBag.OrderList = orderList;
            return View(orderList);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    CustomerId = model.CustomerId,
                    OrderedOn = DateTime.Now,
                    ProductId = model.ProductId,
                    TotalAmount = model.TotalAmount
                };
                var result = await _orderService.AddAsync(order);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }
            Order order = await _orderService.GetById(p => p.Id == id);
            if (order == null)
            {
                return View("NotFound");
            }

            var model = new OrderEditViewModel()
            {
                TotalAmount=order.TotalAmount,
                CustomerId=order.CustomerId,
                ProductId=order.ProductId
            };
            return View(model);


        }
        [HttpPost]
        public async Task<IActionResult> Edit(OrderEditViewModel model)
        {
            var existingOrder = await _orderService.GetById(o => o.Id == model.Id);

            if (existingOrder == null)
            {
                return View("NotFound");
            }

            existingOrder.TotalAmount = model.TotalAmount;
            existingOrder.ProductId = model.ProductId;
            existingOrder.CustomerId = model.CustomerId;
            await _orderService.UpdateAsync(existingOrder);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id > 0)
            {
                var order = await _orderService.GetById(cu => cu.Id == id);
                var result = await _orderService.DeleteAsync(order);
                return RedirectToAction("index");
            }
            return View("index");
        }
    }
}
