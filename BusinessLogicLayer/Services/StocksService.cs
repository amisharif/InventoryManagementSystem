using BusinessLogicLayer.ServiceContracts;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class StocksService : IStocksService
    {
        private readonly ApplicationDbContext _db;
        public StocksService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<Stock>> GetAllStockProducts()
        {
            return await _db.Stocks.Include("Category").Include("Product").ToListAsync();
        }

        public async Task<Stock> GetProductByCtIdProdId(string categoryID, string productID)
        {
            return await _db.Stocks.Include("Category").Include("Product").FirstOrDefaultAsync(prod => prod.Product.CategoryID.ToString() == categoryID && prod.ProductID.ToString() == productID);
        }
    }
}
