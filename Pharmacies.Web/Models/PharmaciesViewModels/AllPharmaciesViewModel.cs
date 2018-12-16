using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacies.Web.Models.PharmaciesViewModels
{
    public class AllPharmaciesViewModel
    {
        public ICollection<PharmacyViewModel> AllPharmacies { get; set; }
    }
}
