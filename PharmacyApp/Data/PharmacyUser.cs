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

        public ICollection<Drug> Drugs { get; set; } = new List<Drug>();

        public override string ToString()
        {
            return this.UserName;
        }
    }
}
