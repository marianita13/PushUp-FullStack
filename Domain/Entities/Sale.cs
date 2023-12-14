using System;

namespace Domain.Entities
{
    public class Sale : BaseEntity
    {
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public ICollection<Payment> MyProperty { get; set; }
    }
}