using System.Collections.Generic;

namespace Pharmacies.Models
{
    public class DrugMedicament
    {
        public int Id { get; set; }

        public string TradeName { get; set; }

        public GenericMedicament Generic { get; set; }

        public int GenericId { get; set; }

        public string Measure { get; set; }

        public string PackingContent { get; set; }

        public ICollection<PurchasedAndSoldDrugMedicament> Reports { get; set; }
    }
}