namespace Lms.Api.DTO
{
    public class UserDTO
    {
       
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? UserType { get; set; }

        public string? CreatedBy { get; set; }

        public DateTimeOffset? CreateDate { get; set; }

        public string? ModifiedBy { get; set; }

        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
