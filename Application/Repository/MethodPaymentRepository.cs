using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;
public class MethodPaymentRepository : GenericRepository<MethodPayment> , IMethodPayment
    {
        private readonly PushUpFullStackContext _context;
        public MethodPaymentRepository(PushUpFullStackContext context) : base(context)
        {
            _context = context;
        }
    }