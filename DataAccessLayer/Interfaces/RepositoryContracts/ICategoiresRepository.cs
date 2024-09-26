using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.RepositoryContracts
{
    public interface ICategoiresRepository
    {
        Task<Category?> AddCategory(Category category);
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategoryByID(Guid id);
        Task<Category> UpdateCategory(Category category);
        Task<bool> DeleteCategoryByID(Guid id);
    }
}
