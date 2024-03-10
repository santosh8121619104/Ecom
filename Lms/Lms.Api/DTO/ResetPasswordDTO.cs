namespace Lms.Api.DTO
{
    public class ResetPasswordDTO
    {
        public string ResetToken { get; set; }
        public string NewPassword { get; set; }
    }
}
