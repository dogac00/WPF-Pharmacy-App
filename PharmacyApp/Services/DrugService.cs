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
        
        public void DeleteDrug(PharmacyUser user, Drug drug)
        {
            user.Drugs.Remove(drug);
            _context.Drugs.Remove(drug);
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void AddDrug(PharmacyUser user, Drug drug)
        {
            user.Drugs.Add(drug);
            _context.Drugs.Add(drug);
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public IEnumerable<Drug> GetAllDrugs(PharmacyUser user)
        {
            return _context
                .Drugs
                .Where(d => d.User.Id == user.Id)
                .ToList();
        }

        public Drug FindDrug(PharmacyUser user, Func<Drug, bool> howToSearch)
        {
            return _context.Drugs
                .Where(d => d.UserId == user.Id)
                .Where(howToSearch)
                .FirstOrDefault();
        }
    }
}
