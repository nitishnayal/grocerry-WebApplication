using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allProducts = await _service.GetAllAsync(n => n.Store);
            return View(allProducts);
        }


        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allProducts = await _service.GetAllAsync(n => n.Store);

            if (!string.IsNullOrEmpty(searchString))
            {
                
                var filteredResultNew = allProducts.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allProducts);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var productDetail = await _service.GetProductByIdAsync(id);
            return View(productDetail);
        }


        public async Task<IActionResult> Create()
        {
            var productDropdownsData = await _service.GetNewProductDropdownsValues();

            ViewBag.Stores = new SelectList(productDropdownsData.Stores, "Id", "Name");
          
            ViewBag.Companies = new SelectList(productDropdownsData.Companies, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewProductVM product)
        {
            if (!ModelState.IsValid)
            {
                var productDropdownsData = await _service.GetNewProductDropdownsValues();

                ViewBag.Stores = new SelectList(productDropdownsData.Stores, "Id", "Name");
                
                ViewBag.Companies = new SelectList(productDropdownsData.Companies, "Id", "FullName");

                return View(product);
            }

            await _service.AddNewProductAsync(product);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {
            var productDetails = await _service.GetProductByIdAsync(id);
            if (productDetails == null) return View("NotFound");

            var response = new NewProductVM()
            {
                Id = productDetails.Id,
                Name = productDetails.Name,
                Description = productDetails.Description,
                Price = productDetails.Price,
                StartDate = productDetails.StartDate,
                EndDate = productDetails.EndDate,
                ImageURL = productDetails.ImageURL,
                ProductCategory = productDetails.ProductCategory,
                StoreId = (int)productDetails.StoreId,
               
                CompanyIds = productDetails.Company_Products.Select(n => n.CompanyId).ToList(),
            };

            var productDropdownsData = await _service.GetNewProductDropdownsValues();
            ViewBag.Stores = new SelectList(productDropdownsData.Stores, "Id", "Name");
           
            ViewBag.Companies = new SelectList(productDropdownsData.Companies, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewProductVM product)
        {
            if (id != product.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var productDropdownsData = await _service.GetNewProductDropdownsValues();

                ViewBag.Stores = new SelectList(productDropdownsData.Stores, "Id", "Name");
               
                ViewBag.Companies = new SelectList(productDropdownsData.Companies, "Id", "FullName");

                return View(product);
            }

            await _service.UpdateProductAsync(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
