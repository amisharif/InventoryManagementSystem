using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ServiceContracts.DTO
{
    public class CategoryUpdateRequest
    {
        public Guid? ID { get; set; }
        public string? CategoryName { get; set; }

        public Category ToCategory()
        {
            return new Category { ID = ID,CategoryName = CategoryName };
        }
    }
}
