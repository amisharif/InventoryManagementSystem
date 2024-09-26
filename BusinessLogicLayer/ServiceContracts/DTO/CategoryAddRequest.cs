using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ServiceContracts.DTO
{
    public class CategoryAddRequest
    {
        public string? CategoryName { get; set; }

        public Category ToCategory()
        {
            return new Category()
            {
                CategoryName = CategoryName,
            };
        }
    }
}
