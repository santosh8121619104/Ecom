using Lms.Api.Models;
using Lms.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lms.Api.Repositories
{
    public class UserProgressRepository : IUserProgressRepository
    {
        private readonly LmsContext _context;

        public UserProgressRepository(LmsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserProgress>> GetAllAsync()
        {
            return await _context.UserProgresses.ToListAsync();
        }

        public async Task<UserProgress> GetByIdAsync(int id)
        {
            return await _context.UserProgresses.FindAsync(id);
        }

        public async Task<IEnumerable<UserProgress>> GetByUserIdAsync(int userId)
        {
            return await _context.UserProgresses.Where(up => up.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<UserProgress>> GetByCourseIdAsync(int courseId)
        {
            return await _context.UserProgresses.Where(up => up.CourseId == courseId).ToListAsync();
        }

        public async Task<IEnumerable<UserProgress>> GetByUserIdAndCourseIdAsync(int userId, int courseId)
        {
            return await _context.UserProgresses.Where(up => up.UserId == userId && up.CourseId == courseId).ToListAsync();
        }

        public async Task AddAsync(UserProgress userProgress)
        {
            _context.UserProgresses.Add(userProgress);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserProgress userProgress)
        {
            _context.Entry(userProgress).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var userProgress = await _context.UserProgresses.FindAsync(id);
            if (userProgress != null)
            {
                _context.UserProgresses.Remove(userProgress);
                await _context.SaveChangesAsync();
            }
        }
    }
}
