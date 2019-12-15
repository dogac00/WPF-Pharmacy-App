using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyApp.Data
{
    public class Vitamin : Product
    {
        public List<Benefit> Benefits { get; set; }

        public Vitamin(string name, decimal price) : base(name, price)
        {
        }

        public void AddBenefit(string benefit)
        {
            this.Benefits.Add(new Benefit(benefit));
        }
    }

    public class Benefit
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Benefit() : this("")
        {
        }

        public Benefit(string name)
        {
            this.Name = name;
        }
    }
}
