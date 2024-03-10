using Lms.Api.DTO;
using Lms.Api.Externalservices.Interfaces;
using Lms.Api.Models;
using Lms.Api.Repositories.Interfaces;
using Lms.Api.Schema.Mutation;
using Mapster;

namespace Lms.Api.GraphQLTypes.Mutations
{
    public class UserMutations
    {
        public async Task<User> CreateUser(UserDTO input, [Service] IUserRepository userRepository)
        {
            User user = input.Adapt<User>();
            await userRepository.AddAsync(user);
            return user;
        }

        public async Task<User> UpdateUser(int id, UserDTO input, [Service] IUserRepository userRepository)
        {
            var user = await userRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            User updateUser = input.Adapt<User>();
            updateUser.UserId= user.UserId;
             await userRepository.UpdateAsync(updateUser);
            return updateUser;
        }

        public async Task<bool> LoginUser(UserDTO input, [Service] IUserRepository userRepository)
        {
            if(string.IsNullOrEmpty(input.Email) || string.IsNullOrEmpty(input.Password))
                return false;
            return await userRepository.LoginAsync(input.Email, input.Password);
        }

        public async Task<bool> ForgotPasswordAsync(string email, [Service] IUserRepository userRepository, [Service] IExternalService externalService)
        {
            var user = await userRepository.GetByEmaiAsync(email);
            if (user == null)
            {
                // Optionally, return true to avoid user enumeration attacks
                return false;
            }

            // Generate a password reset token. This should be securely stored and associated with the user.
            var resetToken = externalService.GenerateResetTokenAsync(email);


            // Send the password reset token to the user's email
            await externalService.SendPasswordResetEmailAsync(user.Email, resetToken.Result);

            return true;
        }
        public async Task<bool> ResetPasswordAsync(ResetPasswordDTO input, [Service] IUserRepository userRepository, [Service] IExternalService externalService)
        {
            // Verify the reset token
            bool isValid = await externalService.ValidateTokenAsync(input.ResetToken);
            if (!isValid)
            {
                throw new GraphQLException("Invalid or expired password reset token.");
            }
            string email = externalService.GetEmailFromToken(input.ResetToken);

            if(!string.IsNullOrEmpty(email))
            {
                User user = await userRepository.GetByEmaiAsync(email);
                if (user != null)
                {
                    user.Password = input.NewPassword;
                    await userRepository.UpdateAsync(user);
                    return true;
                }

            }
            return false;
        }

        public async Task<bool> DeleteUser(int id, [Service] IUserRepository userRepository) =>
            await userRepository.DeleteAsync(id);
    }
}
