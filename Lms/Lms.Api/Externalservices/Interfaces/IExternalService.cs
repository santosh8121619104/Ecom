namespace Lms.Api.Externalservices.Interfaces
{
    public interface IExternalService
    {
        Task<string> GenerateResetTokenAsync(string email);
        string GetEmailFromToken(string resetToken);
        Task SendPasswordResetEmailAsync(string email, string resetToken);
        Task<bool> ValidateTokenAsync(string token);
    }
}
