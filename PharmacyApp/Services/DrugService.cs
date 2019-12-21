using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmacyApp.Data;

namespace PharmacyApp.Services
{
    class DrugService
    {
        private AppDbContext _context;

        public DrugService()
        {
            _context = new AppDbContext();
        }
        
        public async Task DeleteDrugAsync(PharmacyUser user, Drug drug)
        {
            user.Drugs.Remove(drug);
            _context.Drugs.Remove(drug);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task AddDrugAsync(PharmacyUser user, Drug drug)
        {
            user.Drugs.Add(drug);
            await _context.Drugs.AddAsync(drug);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Drug>> GetAllDrugsAsync(PharmacyUser user)
        {
            return await _context
                .Drugs
                .Where(d => d.User.Id == user.Id)
                .ToListAsync();
        }

        public Drug FindDrug(PharmacyUser user, Func<Drug, bool> howToSearch)
        {
            return _context.Drugs
                .Where(d => d.UserId == user.Id)
                .AsEnumerable()
                .Where(howToSearch)
                .FirstOrDefault();
        }
    }
}
