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

        public Drug(string name, string firm, decimal price) : base(name, price)
        {
            this.RelievedSymptoms = new List<Symptom>();
            this.AdverseEffects = new List<AdverseEffect>();
            this.Interactions = new List<Drug>();
            this.Firm = new DrugFirm(firm);
        }

        public void AddSymptomRelief(Symptom symptom)
        {
            this.RelievedSymptoms.Add(symptom);
        }

        public void AddSymptomRelief(string symptom)
        {
            this.RelievedSymptoms.Add(new Symptom(symptom));
        }

        public void AddAdverseEffect(AdverseEffect effect)
        {
            this.AdverseEffects.Add(effect);
        }

        public void AddAdverseEffect(string effect)
        {
            this.AdverseEffects.Add(new AdverseEffect(effect));
        }

        public void AddInteraction(Drug drug)
        {
            this.Interactions.Add(drug);
        }
    }
}
