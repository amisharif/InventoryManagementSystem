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
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoiresRepository _categoiresRepository;
        public CategoriesService(ICategoiresRepository categoiresRepository)
        {
            _categoiresRepository = categoiresRepository;
        }
        public async Task<CategoryResponse?> AddCategory(CategoryAddRequest? categoryAddRequest)
        {
            if (categoryAddRequest == null)
            {
                throw new ArgumentNullException(nameof(categoryAddRequest));
            }
            Category category = categoryAddRequest.ToCategory();
            category.ID = Guid.NewGuid();

            await _categoiresRepository.AddCategory(category);
           
            return category.ToCategoryRespopnse();
        }

        public async Task<bool> DeleteCategoryByID(Guid ID)
        {
          

            Category? category = await _categoiresRepository.GetCategoryByID(ID);
            if (category == null)
                return false;

            await _categoiresRepository.DeleteCategoryByID(ID);

            return true;
        }

        public async Task<List<CategoryResponse>> GetAllCategories()
        {
            List<Category> categories =await _categoiresRepository.GetAllCategories();
            return categories.Select(temp => temp.ToCategoryRespopnse()).ToList();
        }

        public async Task<CategoryResponse?> GetCategoryByID(Guid ID)
        {
            Category category = await _categoiresRepository.GetCategoryByID(ID);
            return category.ToCategoryRespopnse();
        }

        public async Task<CategoryResponse?> UpdateCategory(CategoryUpdateRequest categoryUpdateRequest)
        {
            Category? category = categoryUpdateRequest.ToCategory();
            await _categoiresRepository.UpdateCategory(category);

            return category.ToCategoryRespopnse();
        }
    }
}
