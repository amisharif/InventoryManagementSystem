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
        public Guid CategoryID { get; set; }

        [Required(ErrorMessage ="Enter a category name")]
        public string? CategoryName { get; set; }
    }
}
