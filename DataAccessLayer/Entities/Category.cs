using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Category
    {
        Guid? ID { get; set; }
        public string? CategoryName { get; set; }
    }
}
