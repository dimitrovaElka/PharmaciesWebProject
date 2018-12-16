using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacies.Web.Models.PharmaciesViewModels
{
    public class PharmacyViewModel
    {
        public string Name { get; set; }

        public string CityName { get; set; }

        public string Address { get; set; }

        public string Menager { get; set; }
    }
}
