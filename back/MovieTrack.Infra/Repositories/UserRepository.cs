using Microsoft.EntityFrameworkCore;
using MovieTrack.Domain.Entities;
using MovieTrack.Domain.Interfaces;
using MovieTrack.Infra.Data;

namespace MovieTrack.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MovieTrackDbContext _context;

        public UserRepository(MovieTrackDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetByIdAsync(Guid userId)
        {
            return await _context.Users
                .Include(u => u.UserRelations)
                .Include(u => u.MovieInteractions)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .Include(u => u.UserRelations)
                .Include(u => u.MovieInteractions)
                .FirstOrDefaultAsync(u => u.Email.Address.ToLower() == email.ToLower());
        }

        public async Task<List<User>> GetByNameAsync(string name)
        {
            return await _context.Users
                .Include(u => u.UserRelations)
                .Include(u => u.MovieInteractions)
                .Where(u => u.Name.ToLower().Contains(name.ToLower()))
                .ToListAsync();
        }
    }
}
