using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacies.Models
{
    public class PurchasedAndSoldDrugMedicament
    {
        public int Id { get; set; }

        public Pharmacy Pharmacy { get; set; }

        public int PharmacyId { get; set; }

        public DrugMedicament Drug { get; set; }

        public int DrugMendicamentId { get; set; }

        public ReportingPeriod ReportingPeriod { get; set; }

        public int ReportingPeriodId { get; set; }

        public int PurchasedQuantity { get; set; }

        public int SoldQuantity { get; set; }

    }
}
