
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int ClotheId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public int StockMinimo { get; set; }
        public int StockMaximo { get; set; }
        public string Image { get; set; }
    }
}