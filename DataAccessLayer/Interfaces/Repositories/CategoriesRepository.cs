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
    public class CategoriesRepository : ICategoiresRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoriesRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Category?> AddCategory(Category category)
        {
            if (category == null) throw new ArgumentNullException("Category can't  empty");

            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteCategoryByID(Guid id)
        {
            _db.Categories.RemoveRange(_db.Categories.Where(temp => temp.ID == id));
            int rowsDeleted = await _db.SaveChangesAsync();

            return rowsDeleted > 0;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByID(Guid id)
        {
            Category? category = await _db.Categories.FirstOrDefaultAsync(temp => temp.ID == id);

            if (category == null) throw new ArgumentException(nameof(category.CategoryName));
            return category;
        }

        public async Task<Category> UpdateCategory(Category category)
        {

           Category?matchingCategory = await _db.Categories.FirstOrDefaultAsync(category => category.ID == category.ID);
            if (matchingCategory == null) return category;
            matchingCategory.CategoryName= category.CategoryName;

            int countUpdated = await _db.SaveChangesAsync(); 
            return matchingCategory;
        }
    }
}
