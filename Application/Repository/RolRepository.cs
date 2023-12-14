using Domain.Entities;
using Domain.Interfaces;
using Persistence;
using Persistence.Data;

namespace Application.Repository
{
    public class RolRepository : GenericRepository<Rol>, IRol
    {
        private readonly PushUpFullStackContext _context;

        public RolRepository(PushUpFullStackContext context) : base(context)
        {
            _context = context;
        }
    }
}