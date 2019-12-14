using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task AddUser(PharmacyUser user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public PharmacyUser TryGetUser(string username, string password)
        {
            return _context.Users
                .Where(user => user.UserName == username)
                .FirstOrDefault(user => user.Password == password);
        }
    }
}
