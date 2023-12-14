
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class MethodPaymentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Description { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}