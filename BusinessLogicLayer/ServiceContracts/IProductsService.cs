using BusinessLogicLayer.ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ServiceContracts
{
    public interface IProductsService
    {

        Task<ProductResponse?> AddProduct(ProductAddRequest productAddRequest);
        Task<List<ProductResponse>> GetAllProducts();
        Task<ProductResponse?> GetProductByID(Guid ID);
        Task<ProductResponse?> UpdateProduct(ProductUpdateRequest productUpdateRequest);
        Task<bool> DeleteProductByID(Guid ID);

    }
}
