using Lms.Api.Models;
using Lms.Api.Repositories.Interfaces;
using Mapster;
using System.Collections.Generic;

namespace Lms.Api.GraphQLTypes.Queries
{
    public class EnrollmentQueries:UserQueries
    {
        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByUserIdAsync(int id, [Service] IEnrollmentRepository enrollmentRepository)
        {
           return await enrollmentRepository.GetEnrollmentsByUserIdAsync(id);
          
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseIdAsync(int id, [Service] IEnrollmentRepository enrollmentRepository)
        {
          return await enrollmentRepository.GetEnrollmentsByCourseIdAsync(id);

        }
    }
}
