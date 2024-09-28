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
    public class SalesService : ISalesService
    {
        private readonly ApplicationDbContext _db;
        public SalesService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Sale> AddSale(Sale sale)
        {
            Product product = _db.Products.FirstOrDefault(p => p.ProductID==sale.ProductID);

            if(product != null)
            {
                sale.TotalPrice = sale.Quantity*product.SellingPrice;
            }

            sale.SaleID = Guid.NewGuid();
            await _db.Sales.AddAsync(sale);
            await _db.SaveChangesAsync();

            return sale;
        }

        public async Task<List<Sale>> GetAllSales()
        {
            return await _db.Sales.Include("Category").Include("Product").ToListAsync();
        }
    }
}
