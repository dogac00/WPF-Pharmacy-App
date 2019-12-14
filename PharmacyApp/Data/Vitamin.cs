using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyApp.Data
{
    public class Vitamin : Product
    {
        public List<string> Benefits { get; set; }

        public Vitamin(string name, decimal price) : base(name, price)
        {
        }

        public void AddBenefit(string benefit)
        {
            this.Benefits.Add(benefit);
        }
    }
}
