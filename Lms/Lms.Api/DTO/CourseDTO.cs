using Lms.Api.Models;

namespace Lms.Api.DTO
{
   
    public  class CourseDTO
    {
        public int? CourseId { get; set; }

        public string? CourseName { get; set; }

        public string? Description { get; set; }

        public int? InstructorId { get; set; }

        public string? InstructorName { get; set; }

        public string? CreatedBy { get; set; }

        public DateTimeOffset? CreateDate { get; set; }

        public string? ModifiedBy { get; set; }

        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
