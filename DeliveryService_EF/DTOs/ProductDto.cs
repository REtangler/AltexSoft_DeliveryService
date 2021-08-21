﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService_EF.Models;


namespace DeliveryService_EF.DTOs
{
    [Dapper.Contrib.Extensions.Table("Products")]
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int AmountInStock { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public string Type { get; set; }
    }
}
