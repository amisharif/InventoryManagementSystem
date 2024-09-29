using BusinessLogicLayer.ServiceContracts;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

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
    }
}
