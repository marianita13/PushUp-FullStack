
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int MethodPaymentId { get; set; }
        public int SaleId { get; set; }
        public int NumCard { get; set; }
    }
}