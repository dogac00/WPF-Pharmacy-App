using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PharmacyApp.Data
{
    public class Drug
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredient { get; set; }
        public string RelievedSymptom { get; set; }
        public string AdverseEffect { get; set; }

        public int UserId { get; set; }
        public PharmacyUser User { get; set; }
    }
}
