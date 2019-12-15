using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyApp.Data
{
    public class PharmacyUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public PharmacyInfo Pharmacy { get; set; }

        public PharmacyUser() : this("", "")
        {
            
        }

        public PharmacyUser(string username, string hashedPassword)
        {
            this.UserName = username;
            this.Password = hashedPassword;
            this.Pharmacy = new PharmacyInfo();
        }

        public override string ToString()
        {
            return this.UserName;
        }
    }
}
