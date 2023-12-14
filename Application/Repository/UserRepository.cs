using Application.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class UserRepository : GenericRepository<User>, IUser
    {
        private readonly PushUpFullStackContext _context;

        public UserRepository(PushUpFullStackContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByRefreshTokenAsync(string refreshToken)
        {
            return await _context.User
                .Include(u => u.Rols)
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken));
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.User
                .Include(u => u.Rols)
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
        }
    }
}