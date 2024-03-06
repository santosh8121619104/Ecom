using Lms.Api.Models;
using Lms.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lms.Api.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly LmsContext _context;
        public EnrollmentRepository(LmsContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByUserIdAsync(int userId)
        {
            return await _context.Enrollments.Where(e => e.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseIdAsync(int courseId)
        {
            return await _context.Enrollments.Where(e => e.CourseId == courseId).ToListAsync();
        }
    }
}
