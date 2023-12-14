using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class SaleDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Payment Payment { get; set; }
        public DateOnly ShopDate { get; set; }
        public int Total { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}