using System;

namespace Domain.Entities
{
    public class Sale : BaseEntity
    {
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public Payment Payment { get; set; }
        public DateOnly ShopDate { get; set; }
        public int Total { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}