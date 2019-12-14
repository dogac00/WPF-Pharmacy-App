using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PharmacyApp.Data
{
    class AppDbContext : DbContext
    {
        private string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=PharmacyDb;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<PharmacyUser> Users { get; set; }
    }
}
