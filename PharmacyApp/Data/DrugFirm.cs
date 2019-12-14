using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyApp.Data
{
    public class DrugFirm
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DrugFirm(string name)
        {
            this.Name = name;
        }
    }
}
