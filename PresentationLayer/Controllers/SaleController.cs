﻿using BusinessLogicLayer.ServiceContracts;
using BusinessLogicLayer.ServiceContracts.DTO;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rotativa.AspNetCore;
using System.Reflection.Metadata.Ecma335;

namespace PresentationLayer.Controllers
{
    public class SaleController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IProductsService _productsService;
        private readonly ISalesService _salesService;
        private readonly IStocksService _stocksService;
        public SaleController(ICategoriesService categoriesService, IProductsService productsService,ISalesService salesService, IStocksService stocksService)
        {
            _categoriesService = categoriesService;
            _productsService = productsService;
            _salesService = salesService;
            _stocksService = stocksService;
        }


        //privides the all sales details
        public async Task<IActionResult> Index(DateTime date)
        {

            List<Sale> matchingSale;

            if (date == DateTime.MinValue)
            {
                matchingSale = await _salesService.GetAllSales();
            }
            else
            {
                matchingSale = await _salesService.GetFilterSales(date);
                return PartialView(matchingSale);
            }

           
            return View(matchingSale);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddSale()
        {
            List<CategoryResponse> categories = await _categoriesService.GetAllCategories();
            //sending categroy to the view with key value pair
            ViewBag.Categories = categories.Select(temp =>
              new SelectListItem() { Text = temp.CategoryName, Value = temp.ID.ToString() }
            );

            ViewBag.Products = new List<SelectListItem>();
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddSale(Sale sale)
        {
            //adding new product to the sales table
            await _salesService.AddSale(sale);
            return RedirectToAction("Index");
        }


        //Get all stock product and return Product Name and product ID as a selectListItem
        [HttpGet]
        public async Task<ActionResult> GetProducts(string categoryID)
        {
            List<ProductResponse> products = await _productsService.GetAllProducts();

            //   var filterProducts = products.Where(prod => prod.CategoryID.ToString() == categoryID).ToList();

            List<Stock> stocks = await _stocksService.GetAllStockProducts();

            List<SelectListItem> productsSel = stocks.Where(st => st.CategoryID.ToString()==categoryID).Select(c => new SelectListItem()
            {
                Text = c.Product?.ProductName,
                Value = c.Product?.ProductID.ToString()
            }).ToList();
            return Json(productsSel);
        }


        [HttpGet]
        public async Task<ActionResult> GetSelectedProducts(string categoryID,string productID)
        {
            Stock stock = await _stocksService.GetProductByCtIdProdId(categoryID, productID);

            return Json(stock);

        }



        [HttpGet]
        public async Task<IActionResult> SalesPDF()
        {

            List<Sale> sales = await _salesService.GetAllSales();

            return new ViewAsPdf(sales);
        }




    }
}
