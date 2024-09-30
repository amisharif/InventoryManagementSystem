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
    public class Sale
    {

        [Key]
        public Guid SaleID { get; set; }

        public Guid CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public Category? Category { get; set; }

        public Guid ProductID { get; set; }
        [ForeignKey("ProductID")]
        public Product? Product { get; set; }

        [Range(1, Int32.MaxValue, ErrorMessage = "Enter a valid quantity")]
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }

        [DataType(DataType.Date)]
        public DateTime SaleDate { get; set; }

    }
}
