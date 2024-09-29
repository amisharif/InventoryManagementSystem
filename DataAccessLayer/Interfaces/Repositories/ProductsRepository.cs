using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.Repositories
{
   
    public class ProductsRepository : IProductsRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductsRepository(ApplicationDbContext db)
        {
            _db  = db;
        }

        public async Task<Product> AddProduct(Product product)
        {

            //get stock product by CategoryId and Product Name if scock is null add new product to the stock else update the existing stock's product

            Stock? stock = await _db.Stocks.Include("Category").Include("Product").FirstOrDefaultAsync(st=>st.Category.CategoryID==product.CategoryID && st.Product.ProductName==product.ProductName);

            if (stock == null)
            {
                Stock stocks = new Stock()
                {
                    StockID = Guid.NewGuid(),
                    CategoryID = (Guid)product.CategoryID,
                    ProductID = product.ProductID,
                    Quantity = product.Quantity
                };

                await _db.Stocks.AddAsync(stocks);
            }
            else
            {
                stock.Quantity = stock.Quantity + product.Quantity;
               // await _db.Stocks.AddAsync(stock);
            }

            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();

            return product;
        }

        public async Task<bool> DeleteProductByID(Guid ID)
        {
            _db.Products.RemoveRange(_db.Products.Where(temp => temp.ProductID == ID));
            int rowsDeleted = await _db.SaveChangesAsync();
            return rowsDeleted > 0;
        }

        public async Task<List<Product>> GetAllProducts()
        {     
            return await _db.Products.Include("Category").ToListAsync();
        }

        public async Task<Product> GetProductByID(Guid ID)
        {
            Product? matchingProduct = await _db.Products.Include("Category").FirstOrDefaultAsync(temp=>temp.ProductID== ID);

            if (matchingProduct == null) { throw new ArgumentException(nameof(ID)); }

            return matchingProduct;
        }

        public async Task<Product> UpdateProduct(Product product)
        {

            Product? matchingProducts = _db.Products.FirstOrDefault(prod=>prod.ProductID== product.ProductID);

            if (matchingProducts == null) return product;
            matchingProducts.ProductName = product.ProductName;
            matchingProducts.Quantity = product.Quantity;
            matchingProducts.BuyingPrice = product.BuyingPrice;
            matchingProducts.SellingPrice = product.SellingPrice;
            matchingProducts.ProductAddedTime = product.ProductAddedTime;
            matchingProducts.CategoryID = product.CategoryID;

            await _db.SaveChangesAsync();

            return matchingProducts;
        }


    }
}
