using CustomerOrderManagement.Models.EntityModels;
using CustomerOrderManagement.Models.ViewModels.Customers;
using CustomerOrderManagement.Service.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderManagement.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<IActionResult> Index()
        {
            var customers =await _customerService.GetAllAsync();
            var model = new CustomerIndexViewModel();
            model.Customers = (List<Customer>)customers;
            return View(model);
        }
        public async Task<IActionResult> Create()
        {
            var model = new CustomerCreateViewModel();
            model.Customers = (List<Customer>?)await _customerService.GetAllAsync();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateViewModel model)
        {
            bool success = false;
            if (ModelState.IsValid)
            { 
                var customer = new Customer()
                {
                    CategoryId=1,
                    Name = model.Name, 
                    PhoneNo = model.PhoneNo,
                    Address = model.Address,
                };
                await _customerService.AddAsync(customer);
                return RedirectToAction("Index");
            }
            if(success)
            {
                return RedirectToAction("Create");
            }

            model.Customers = (List<Customer>?)await _customerService.GetAllAsync();

            return View(model);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }
            Customer customer =await _customerService.GetById(cu=>cu.Id==id);
            if(customer == null)
            {
                return View("NotFound");
            }

            var model = new CustomerEditViewModel()
            {
                Id=customer.Id,
                Name = customer.Name,
                PhoneNo = customer.PhoneNo,
                Address = customer.Address
            };


            return View(model);


        }
        [HttpPost]
        public async Task<IActionResult> Edit(CustomerEditViewModel model)
        {
            var existingCustomer =await _customerService.GetById(cu=>cu.Id==model.Id); 

            if(existingCustomer == null)
            {
                return View("NotFound");
            }

            existingCustomer.Name = model.Name; 
            existingCustomer.PhoneNo = model.PhoneNo;
            existingCustomer.Address = model.Address;
            await _customerService.UpdateAsync(existingCustomer);

            return RedirectToAction("Index");
        }
    }
}
