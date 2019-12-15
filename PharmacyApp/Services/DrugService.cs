using System;
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

        public Drug FindDrug(PharmacyUser user, string name)
        { 
            foreach (Drug drug in user.Pharmacy.Drugs)
                if (drug.Name == name)
                    return drug;

            return null;
        }

        public async Task AddDrugAsync(PharmacyUser user, Drug drug)
        {
            user.Pharmacy.Drugs.Add(drug);
            _context.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
