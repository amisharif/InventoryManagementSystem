using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.RepositoryContracts
{
    public interface IProductsRepository
    {
        Task<Product> AddProduct(Product product);
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductByID(Guid ID);
        Task<Product> UpdateProduct(Product product);
        Task<bool> DeleteProductByID(Guid ID);
    }
}
