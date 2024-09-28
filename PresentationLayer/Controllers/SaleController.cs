using BusinessLogicLayer.ServiceContracts;
using BusinessLogicLayer.ServiceContracts.DTO;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PresentationLayer.Controllers
{
    public class SaleController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IProductsService _productsService;
        private readonly ISalesService _salesService;
        public SaleController(ICategoriesService categoriesService, IProductsService productsService,ISalesService salesService)
        {
            _categoriesService = categoriesService;
            _productsService = productsService;
            _salesService = salesService;
        }


        public async Task<IActionResult> Index()
        {
            List<Sale> sales = await _salesService.GetAllSales();
            return View(sales);
        }


        public async Task<IActionResult> AddSale()
        {
            List<CategoryResponse> categories = await _categoriesService.GetAllCategories();

            ViewBag.Categories = categories.Select(temp =>
              new SelectListItem() { Text = temp.CategoryName, Value = temp.ID.ToString() }
            );

            ViewBag.Products = new List<SelectListItem>();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSale(Sale sale)
        {

            await _salesService.AddSale(sale);
            return View();
        }


        [HttpGet]
        public async Task<ActionResult> GetProducts(string categoryID)
        {
            List<ProductResponse> products = await _productsService.GetAllProducts();

         //   var filterProducts = products.Where(prod => prod.CategoryID.ToString() == categoryID).ToList();

            List<SelectListItem> productsSel = products.Where(prod => prod.CategoryID.ToString()==categoryID).Select(c => new SelectListItem()
            {
                Text = c.ProductName,
                Value = c.ProductID.ToString()
            }).ToList();
            return Json(productsSel);
        }




    }
}
