
using BusinessLogicLayer.ServiceContracts;
using BusinessLogicLayer.ServiceContracts.DTO;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;
        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
            
        }
        public async Task<ProductResponse?> AddProduct(ProductAddRequest productAddRequest)
        {
            Product product = productAddRequest.ToProduct();
            product.ProductID = Guid.NewGuid();
          //  product.ProductAddedTime = DateTime.Now;

            await _productsRepository.AddProduct(product);
            return product.ToProductResonse();

        }

        public async Task<bool> DeleteProductByID(Guid ID)
        {
            Product product = await _productsRepository.GetProductByID(ID);
            if (product == null)
            {
                return false;
            }
            await _productsRepository.DeleteProductByID(ID);
            return true;
        }

        public async Task<List<ProductResponse>> GetAllProducts()
        {
            List<Product> products = await _productsRepository.GetAllProducts();
            //   if (products == null || products.Count == 0) throw new ArgumentException();
            if (products == null) return null;

            return products.Select(prod=>prod.ToProductResonse()).ToList();
        }

        public async Task<List<ProductResponse>> GetFilterProducts(DateTime date)
        {
            List<Product> filterProducts = await _productsRepository.GetFilterProducts(date);
            return filterProducts.Select(prod=>prod.ToProductResonse()).ToList();
        }

        public async Task<ProductResponse?> GetProductByID(Guid ID)
        {
            Product product = await _productsRepository.GetProductByID(ID);

            return product.ToProductResonse() ;
        }

        public async Task<ProductResponse?> UpdateProduct(ProductUpdateRequest productUpdateRequest)
        {
            Product product = productUpdateRequest.ToProduct() ;
            product.ProductAddedTime = DateTime.Now;

            await _productsRepository.UpdateProduct(product);
            return product.ToProductResonse();
        }
    }
}
