using BusinessLogicLayer.ServiceContracts;
using BusinessLogicLayer.ServiceContracts.DTO;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata.Ecma335;

namespace PresentationLayer.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IProductsService _productsService;
        public ProductController(ICategoriesService categoriesService,IProductsService productsService)
        {
            _categoriesService = categoriesService;
            _productsService = productsService;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductResponse> products =await _productsService.GetAllProducts();
           // if (products == null) return RedirectToAction("Create");

            return View(products);
        }

        [HttpGet]
        public async Task< IActionResult> Create()
        {

            List<CategoryResponse> categories = await _categoriesService.GetAllCategories();
            ViewBag.Categories = categories.Select(temp =>
              new SelectListItem() { Text = temp.CategoryName, Value = temp.ID.ToString() }
            );

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductAddRequest product)
        {
            ProductResponse? productResponse = await _productsService.AddProduct(product);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid ID)
        {

            List<CategoryResponse> categories = await _categoriesService.GetAllCategories();
            ViewBag.Categories = categories.Select(temp =>
              new SelectListItem() { Text = temp.CategoryName, Value = temp.ID.ToString() }
            );

            ProductResponse? productResponse = await _productsService.GetProductByID(ID);
            ProductUpdateRequest? productUpdateRequest =  productResponse?.ToProductUpdateRequest();

            return View(productUpdateRequest);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(ProductUpdateRequest productUpdateRequest)
        {
            ProductResponse? productResponse = await _productsService.GetProductByID(productUpdateRequest.ProductID);

            if (productResponse == null)
            {
                return RedirectToAction("Index");
            }

            ProductResponse? updateProduct = await _productsService.UpdateProduct(productUpdateRequest);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid ID)
        {
            await _productsService.DeleteProductByID(ID);
            return RedirectToAction("Index");
        }




    }
}
