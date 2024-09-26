using BusinessLogicLayer.ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ServiceContracts
{
    public interface ICategoriesService
    {
        Task<CategoryResponse?> AddCategory(CategoryAddRequest categoryAddRequest);
        Task<List<CategoryResponse>> GetAllCategories();
        Task<CategoryResponse?> GetCategoryByID(Guid ID);
        Task<CategoryResponse?> UpdateCategory(CategoryUpdateRequest categoryUpdateRequest);
        Task<bool> DeleteCategoryByID(Guid ID);
    }
}
