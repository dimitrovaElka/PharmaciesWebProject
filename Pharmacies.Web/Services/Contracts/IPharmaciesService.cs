using Pharmacies.Web.Models.PharmaciesViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Pharmacies.Web.Services.Contracts
{
    public interface IPharmaciesService
    {
        IQueryable<PharmacyViewModel> All();
    }
}
