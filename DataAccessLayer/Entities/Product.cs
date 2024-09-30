using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Product
    {
        [Key]
        public Guid ProductID { get; set; }

        [StringLength(40)] //nvarchar(40)
        [Required(ErrorMessage ="Enter a product name")]
        public string? ProductName { get; set; }

        [Range(1, Int32.MaxValue, ErrorMessage = "Enter a valid quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage ="Buying price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Enter a valid price")]
        public double BuyingPrice { get; set; }

        [Required(ErrorMessage = "Selling price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Enter a valid price")]
        public double SellingPrice { get; set; }

        public DateTime ProductAddedTime { get; set; }


        //uniqueidentifier
        public Guid? CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public  Category? Category { get; set; }
    }
}
