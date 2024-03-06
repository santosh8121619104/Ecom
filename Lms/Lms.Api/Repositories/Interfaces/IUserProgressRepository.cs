using Lms.Api.Models;

namespace Lms.Api.Repositories.Interfaces
{
    public interface IUserProgressRepository
    {
        Task<IEnumerable<UserProgress>> GetAllAsync();
        Task<UserProgress> GetByIdAsync(int id);
        Task<IEnumerable<UserProgress>> GetByUserIdAsync(int userId);
        Task<IEnumerable<UserProgress>> GetByCourseIdAsync(int courseId);
        Task<IEnumerable<UserProgress>> GetByUserIdAndCourseIdAsync(int userId, int courseId);
        Task AddAsync(UserProgress userProgress);
        Task UpdateAsync(UserProgress userProgress);
        Task DeleteAsync(int id);
    }
}
