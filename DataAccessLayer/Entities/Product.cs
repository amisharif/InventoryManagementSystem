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
        public string? ProductName { get; set; }

        public int Quantity { get; set; }
        public double BuyingPrice { get; set; }
        public double SellingPrice { get; set; }
        public DateTime ProductAddedTime { get; set; }


        //uniqueidentifier
        public Guid? CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public  Category? Category { get; set; }
    }
}
