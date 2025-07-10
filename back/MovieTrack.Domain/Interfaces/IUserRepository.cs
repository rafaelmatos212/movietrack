using MovieTrack.Domain.Entities;

namespace MovieTrack.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> AddAsync(User user);
        public Task<User?> GetByIdAsync(Guid userId);
        public Task<User?> GetByEmailAsync(string email);
        public Task<List<User>> GetByNameAsync(string name);
    }
}
