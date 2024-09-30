using BusinessLogicLayer.ServiceContracts;
using BusinessLogicLayer.ServiceContracts.DTO;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace PresentationLayer.Controllers
{
    public class StockController : Controller
    {
        private readonly IStocksService _stocksService;
        public StockController(IStocksService stocksService)
        {
            _stocksService = stocksService;
        }
        public async Task<IActionResult> Index()
        {
            List<Stock> stocks = await _stocksService.GetAllStockProducts();
            return View(stocks);
        }


        public async Task<IActionResult> StocksPDF()
        {
            List<Stock> stocks = await _stocksService.GetAllStockProducts();
            return new ViewAsPdf("StocksPDF", stocks, ViewData)
            {
                PageMargins = new Rotativa.AspNetCore.Options.Margins() { Top = 20, Right = 20, Bottom = 20, Left = 20 },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
            };
        }


    }
}
