using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacies.Models
{
    public class GenericMedicament
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<DrugMedicament> Drugs { get; set; }
    }
}
