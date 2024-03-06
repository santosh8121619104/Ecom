using Lms.Api.DTO;
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

        public async Task<bool> DeleteUser(int id, [Service] IUserRepository userRepository) =>
            await userRepository.DeleteAsync(id);
    }

}
