namespace Lms.Api.Repositories.Interfaces;

using Lms.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUserRepository
{
    Task<User> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync();
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task <bool> DeleteAsync(int id);
    Task<bool> LoginAsync(string email, string password);
    Task<User> GetByEmaiAsync(string email);
}
