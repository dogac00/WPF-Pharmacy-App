using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyApp.Data
{
    public class Drug : Product
    {
        public List<Symptom> RelievedSymptoms { get; set; }
        public List<AdverseEffect> AdverseEffects { get; set; }
        public List<Drug> Interactions { get; set; }
        public DrugFirm Firm { get; set; }
        public Ingredient Ingredient { get; set; }

        public Drug() : base("", 0)
        {
            this.RelievedSymptoms = new List<Symptom>();
            this.AdverseEffects = new List<AdverseEffect>();
            this.Interactions = new List<Drug>();
            this.Firm = new DrugFirm("");
        }

        public Drug(string name, string firm, decimal price) : base(name, price)
        {
            this.RelievedSymptoms = new List<Symptom>();
            this.AdverseEffects = new List<AdverseEffect>();
            this.Interactions = new List<Drug>();
            this.Firm = new DrugFirm(firm);
        }

        public GridDrug ToGridDrug()
        {
            return new GridDrug
            {
                Name = this.Name,
                Firm = this.Firm.Name,
                Ingredient = this.Ingredient.Name
            };
        }
    }

    public class GridDrug
    {
        public string Name { get; set; }
        public string Firm { get; set; }
        public string Ingredient { get; set; }
    }
}
