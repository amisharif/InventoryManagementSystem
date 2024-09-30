using BusinessLogicLayer.ServiceContracts;
using BusinessLogicLayer.ServiceContracts.DTO;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rotativa.AspNetCore;
using System;
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


        public async Task<IActionResult> Index(DateTime date)
        {
            List<ProductResponse> matchingProducts;

            if (date == DateTime.MinValue)
            {
                matchingProducts = await _productsService.GetAllProducts();
                if (matchingProducts == null) RedirectToAction("Create");
            }
            else
            {
                matchingProducts = await _productsService.GetFilterProducts(date);
                return PartialView(matchingProducts);
            }
       
            return View(matchingProducts);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task< IActionResult> Create()
        {

            List<CategoryResponse> categories = await _categoriesService.GetAllCategories();
            ViewBag.Categories = categories.Select(temp =>
              new SelectListItem() { Text = temp.CategoryName, Value = temp.ID.ToString() }
            );

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(ProductAddRequest product)
        {
            //Sending data to the products service to add new product to the Products table
            ProductResponse? productResponse = await _productsService.AddProduct(product);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(ProductUpdateRequest productUpdateRequest)
        {
            ProductResponse? productResponse = await _productsService.GetProductByID(productUpdateRequest.ProductID);

            if (productResponse == null)
            {
                return RedirectToAction("Index");
            }
            //Sending modified products details to the products service 
            ProductResponse? updateProduct = await _productsService.UpdateProduct(productUpdateRequest);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(Guid ID)
        {
            await _productsService.DeleteProductByID(ID);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> ProductsPDF()
        {
            List<ProductResponse> products = await _productsService.GetAllProducts();
            return new ViewAsPdf("ProductsPDF", products, ViewData)
            {
                PageMargins = new Rotativa.AspNetCore.Options.Margins() { Top = 20, Right = 20, Bottom = 20, Left = 20 },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
            };
        }




    }
}
