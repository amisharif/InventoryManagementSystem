using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Category
    {
        [Key]
        public Guid? ID { get; set; }
        public string? CategoryName { get; set; }
    }
}
