using Lms.Api.Repositories.Interfaces;
using Lms.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate;

namespace Lms.Api.GraphQLTypes.Queries
{
    public class CourseQueries:EnrollmentQueries
    {
        public async Task<Course> GetCourseAsync(int id, [Service] ICourseRepository courseRepository)
        {
            return await courseRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Course>> GetCoursesAsync([Service] ICourseRepository courseRepository)
        {
            return await courseRepository.GetAllAsync();
        }
    }
}
