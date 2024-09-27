using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ServiceContracts.DTO
{
    public class CategoryResponse
    {
        [Key]
        public Guid ID { get; set; }
        public string? CategoryName { get; set; }

        public CategoryUpdateRequest ToCategoryUpdateRequest()
        {
            return new CategoryUpdateRequest()
            {
                ID = ID,
                CategoryName = CategoryName
            };
        }
    }

    public static class CategoryExtension
    {
        public static CategoryResponse ToCategoryRespopnse (this Category category)
        {
            return new CategoryResponse()
            {
                ID = category.CategoryID,
                CategoryName = category.CategoryName,
            };
        }
    }
}
