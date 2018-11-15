using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacies.Models
{
    public class Stock
    {
        public int Id { get; set; }

        public Pharmacy Pharmacy { get; set; }

        public int PharmacyId { get; set; }

        public DrugMedicament Drug { get; set; }

        public int DrugMendicamentId { get; set; }

        public DateTime ReportingDate { get; set; }

        public int StockOfMedicament { get; set; }
    }
}
