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

        public async Task<IActionResult> Index()
        {
            var productList = await _productService.GetAllAsync();
            ViewBag.ProductList = productList;
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
                var productList = await _productService.GetAllAsync();
                ViewBag.ProductList = productList;
                return RedirectToAction("index",productList);
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id > 0)
            {
                var customer = await _productService.GetById(p => p.Id == id);
                var result = await _productService.DeleteAsync(customer);
                var productList = await _productService.GetAllAsync();
                ViewBag.ProductList = productList;
                return RedirectToAction("index", productList);
            }
            return View("index");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }
            Product product = await _productService.GetById(p => p.Id == id);
            if (product == null)
            {
                return View("NotFound");
            }

            var model = new ProductEditViewModel()
            {
               Id=product.Id,
               Description = product.Description,
               Name = product.Name,
               UnitPrice= product.UnitPrice
            };

            return View(model);


        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditViewModel model)
        {
            var existingProduct = await _productService.GetById(p => p.Id == model.Id);

            if (existingProduct == null)
            {
                return View("NotFound");
            }

            existingProduct.Description = model.Description;    
            existingProduct.Name = model.Name;
            existingProduct.UnitPrice = model.UnitPrice;
            await _productService.UpdateAsync(existingProduct);
            return RedirectToAction("Index");
        }
    }
}
