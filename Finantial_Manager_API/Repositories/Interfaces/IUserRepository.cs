using Finantial_Manager_API.Models;

namespace Finantial_Manager_API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(Guid id);
        Task<bool> EmailExistsAsync(string email);
        Task<User> CreateAsync(User user);
    }
}
