using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmacyApp.Data;

namespace PharmacyApp.Services
{
    class UserService
    {
        private AppDbContext _context;

        public UserService()
        {
            _context = new AppDbContext();
        }

        public async Task AddUserAsync(PharmacyUser user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsUsernameTaken(string username)
        {
            return await _context
                .Users
                .AnyAsync(u => u.UserName == username);
        }

        public PharmacyUser TryGetUser(string username, string password)
        {
            return _context.Users
                .Where(user => user.UserName == username)
                .FirstOrDefault(user => user.Password == password);
        }
    }
}
