﻿using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ServiceContracts.DTO
{
    public class ProductUpdateRequest
    {
    
        public Guid ProductID { get; set; }

        [StringLength(40)] //nvarchar(40)
        public string? ProductName { get; set; }

        public int Quantity { get; set; }
        public double BuyingPrice { get; set; }
        public double SellingPrice { get; set; }
        public DateTime? ProductAddedTime { get; set; }


        //uniqueidentifier
        public Guid? CategoryID { get; set; }

        public  Category? Category { get; set; }

        public Product ToProduct()
        {
            return new Product()
            {
                ProductID = ProductID,
                ProductName = ProductName,
                Quantity = Quantity,
                BuyingPrice = BuyingPrice,
                SellingPrice = SellingPrice,
                CategoryID = CategoryID,
                Category = Category,
  
            };
        }

    }
}
