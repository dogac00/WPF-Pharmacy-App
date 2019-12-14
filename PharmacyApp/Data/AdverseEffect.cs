using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyApp.Data
{
    public class AdverseEffect
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public AdverseEffect(string name)
        {
            this.Name = name;
        }
    }
}
