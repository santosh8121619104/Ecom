using Lms.Api.Models;
using Lms.Api.Repositories.Interfaces;

namespace Lms.Api.GraphQLTypes.Queries
{
    public class UserQueries
    {
        public async Task<User> GetUserByIdAsync(int id, [Service] IUserRepository userRepository) =>
        await userRepository.GetByIdAsync(id);

        public async Task<IEnumerable<User>> GetAllUsersAsync([Service] IUserRepository userRepository) =>
            await userRepository.GetAllAsync();
    }
}
