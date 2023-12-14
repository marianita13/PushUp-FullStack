using System;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
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