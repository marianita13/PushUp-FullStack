using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;
public class SaleRepository : GenericRepository<Sale> , ISale
    {
        private readonly PushUpFullStackContext _context;
        public SaleRepository(PushUpFullStackContext context) : base(context)
        {
            _context = context;
        }
    }