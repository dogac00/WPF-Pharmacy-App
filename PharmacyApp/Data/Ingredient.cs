using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyApp.Data
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Ingredient() : this("")
        {
            
        }

        public Ingredient(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
