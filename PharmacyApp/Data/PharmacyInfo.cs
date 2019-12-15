using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyApp.Data
{
    public class PharmacyInfo
    {
        public int Id { get; set; }
        public List<Drug> Drugs { get; set; }
        public List<Vitamin> Vitamins { get; set; }
        public List<Product> OtherProducts { get; set; }

        public PharmacyInfo()
        {
            this.Drugs = new List<Drug>();
            this.Vitamins = new List<Vitamin>();
            this.OtherProducts = new List<Product>();
        }
    }
}
