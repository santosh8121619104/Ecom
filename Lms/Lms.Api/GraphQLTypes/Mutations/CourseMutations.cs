
using Lms.Api.DTO;
using Lms.Api.Models;
using Lms.Api.Repositories.Interfaces;
using Mapster;

namespace Lms.Api.GraphQLTypes.Mutations
{
    public class CourseMutations:UserMutations
    {
        public async Task<Course> CreateCourse(CourseDTO input, [Service] ICourseRepository courseRepository)
        {
            var course = input.Adapt<Course>();
            await courseRepository.AddAsync(course);
            return course; 
        }

        public async Task<Course> UpdateCourse(CourseDTO input, [Service] ICourseRepository courseRepository)
        {
            var course = input.Adapt<Course>();
           await courseRepository.UpdateAsync(course);

            return course;
        }


        public async Task<bool> DeleteCourse(int id, [Service] ICourseRepository courseRepository)
        {
            return await courseRepository.DeleteAsync(id);
        }
    }
}
