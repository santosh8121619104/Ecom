using Lms.Api.Models;
using Lms.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Lms.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LmsContext _context;

        public UserRepository(LmsContext context)
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetByEmaiAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return false;
            _context.Set<User>().Remove(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            User user = await _context.Users.FirstOrDefaultAsync(a => a.Email == email && a.Password == password);
            if (user == null)
            {
                return false;
            }
            return true;
        }
    }
}
