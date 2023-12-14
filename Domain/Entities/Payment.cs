using System;

namespace Domain.Entities
{
    public class Payment : BaseEntity
    {
        public MethodPayment MethodPayment { get; set; }
        public int MethodPaymentId { get; set; }
        public Sale Sale { get; set; }
        public int SaleId { get; set; }
        public int NumCard { get; set; }
    }
}