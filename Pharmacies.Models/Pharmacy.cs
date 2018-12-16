using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacies.Models
{
    public class Pharmacy
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Eik { get; set; }

        public string PharmacyLicense { get; set; }

        public string DrugsLicense { get; set; }

        public City City { get; set; }

        public int CityId { get; set; }

        public string Address { get; set; }

        public PharmaciesUser Menager { get; set; }

        public int PharmaciesUserId { get; set; }

        public string Telefon { get; set; }

        public string Email { get; set; }

        public ICollection<PurchasedAndSoldDrugMedicament> Reports { get; set; }
    }
}
