using Finantial_Manager_API.Data;
using Finantial_Manager_API.Models;
using Finantial_Manager_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Finantial_Manager_API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) => _context = context;

        public async Task<User> CreateAsync(User user)
        {
            user.Email = user.Email.ToLower();
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Users
                .AnyAsync(u => u.Email == email.ToLower());
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email.ToLower() && u.IsActive);
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id && u.IsActive);
        }
    }
}
