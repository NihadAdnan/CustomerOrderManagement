using CustomerOrderManagement.Models.EntityModels;
using CustomerOrderManagement.Models.ViewModels.Products;
using CustomerOrderManagement.Service.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderManagement.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        
        {
            var productList=await _productService.GetAllAsync();
            ViewBag.ProductList = productList;  
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Description = model.Description,
                    Name = model.Name,
                    UnitPrice = model.UnitPrice
                };
                var result = await _productService.AddAsync(product);
                return RedirectToAction("ProductList");
            }
            return View(model);
        }
        public async Task<IActionResult> ProductList()
        {
            var productList = await _productService.GetAllAsync();
            ViewBag.ProductList = productList;
            return View();
        }
    }
}
