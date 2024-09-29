using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Stock
    {
        [Key]
        public Guid StockID { get; set; }

        public Guid CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public Category? Category { get; set; }

        public Guid ProductID { get; set; }

        [ForeignKey("ProductID")]
        public Product? Product { get; set; }

        public int Quantity { get; set; }
    }
}
