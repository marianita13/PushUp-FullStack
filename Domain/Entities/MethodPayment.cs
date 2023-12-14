using System;

namespace Domain.Entities
{
    public class MethodPayment : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}