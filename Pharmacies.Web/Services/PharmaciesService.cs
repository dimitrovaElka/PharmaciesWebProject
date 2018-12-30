using Microsoft.EntityFrameworkCore;
using Pharmacies.Data;
using Pharmacies.Models;
using Pharmacies.Web.Models.PharmaciesViewModels;
using Pharmacies.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacies.Web.Services
{
    public class PharmaciesService : IPharmaciesService
    {
        private readonly PharmaciesDbContext dbContext;

        public PharmaciesService(PharmaciesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<PharmacyViewModel> All() => this.dbContext.Pharmacies
            .Include(ph => ph.City)
            .Select(a => new PharmacyViewModel
            {
                Name = a.Name,
                CityName = a.City.Name,
                Address = a.Address,
                Manager = a.Manager
            });
    }
}
