using Lms.Api.Externalservices.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace Lms.Api.Externalservices
{
    public class ExternalService : IExternalService
    {
        private readonly IConfiguration _configuration;
        public ExternalService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task<string> GenerateResetTokenAsync(string email)
        {
            return Task.FromResult(GenerateResetToken(email));
        }

        public Task<bool> ValidateTokenAsync(string token)
        {
            return Task.FromResult(ValidateToken(token));
        }

        public async Task SendPasswordResetEmailAsync(string userEmail, string resetToken)
        {
            string sendGridKey = _configuration["SendGridKey"] ?? string.Empty;
            var client = new SendGridClient(sendGridKey);
            var from = new EmailAddress("Admin@Lms.com", "Admin");
            var subject = "Reset Your Password";
            var to = new EmailAddress(userEmail);
            var plainTextContent = $"Click the following link to reset your password: https://example.com/reset-password?token={resetToken}";
            var htmlContent = $"<strong>Click the following link to reset your password:</strong> <a href='https://example.com/reset-password?token={resetToken}'>Reset Password</a>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            if (response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.Accepted)
            {
                throw new Exception($"Failed to send email: {response.StatusCode}");
            }
        }

        public string GenerateResetToken(string email)
        {
            const int TokenLength = 32;
            const int ExpiryHours = 24;
            const string EncryptionKey = "YourEncryptionKey";
            // Encrypt the email
            string encryptedEmail = EncryptString(email, EncryptionKey);

            // Create a buffer to hold the random bytes
            byte[] tokenBytes = new byte[TokenLength];

            // Use a cryptographically secure random number generator
            using (var rng = new RNGCryptoServiceProvider())
            {
                // Fill the buffer with random bytes
                rng.GetBytes(tokenBytes);
            }

            // Convert the random bytes to a hexadecimal string
            string token = BitConverter.ToString(tokenBytes).Replace("-", "").ToLower();

            // Create a DateTime object for token expiry (24 hours from now)
            DateTime expiryTime = DateTime.UtcNow.AddHours(ExpiryHours);

            // Convert the expiry time to a string (e.g., "yyyy-MM-ddTHH:mm:ss.fffZ")
            string expiryTimeString = expiryTime.ToString("o");

            // Append the encrypted email and expiry time to the token
            token += "|" + encryptedEmail + "|" + expiryTimeString;

            return token;
        }

        private string EncryptString(string input, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[16]; // Use a zero IV for simplicity (not recommended for production)

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] encryptedBytes = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

                return Convert.ToBase64String(encryptedBytes);
            }
        }

        public bool ValidateToken(string token)
        {
            // Split the token into parts
            string[] parts = token.Split('|');

            // Ensure the token has at least two parts (email and expiry time)
            if (parts.Length < 2)
            {
                return false;
            }

            // Get the expiry time from the token
            if (!DateTime.TryParse(parts[1], out DateTime expiryTime))
            {
                return false;
            }

            // Check if the token has expired
            if (expiryTime < DateTime.UtcNow)
            {
                return false;
            }

            return true;
        }

        public string GetEmailFromToken(string token)
        {
            const string EncryptionKey = "YourEncryptionKey";
            // Split the token into parts
            string[] parts = token.Split('|');

            // Ensure the token has at least two parts (email and expiry time)
            if (parts.Length < 2)
            {
                return null;
            }

            // The email is the first part of the token
            string encryptedEmail = parts[0];

            // Decrypt the email
            string email = DecryptString(encryptedEmail, EncryptionKey);

            return email;
        }

        private string DecryptString(string encryptedInput, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[16];

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                byte[] encryptedBytes = Convert.FromBase64String(encryptedInput);
                byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }
    }


}

