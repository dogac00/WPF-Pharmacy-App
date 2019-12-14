using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyApp.Data
{
    public class Symptom
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Symptom(string name)
        {
            this.Name = name;
        }
    }
}
