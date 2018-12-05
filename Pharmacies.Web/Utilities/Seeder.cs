using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Pharmacies.Data;
using Pharmacies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacies.Web.Utilities
{
    public class Seeder
    {
        public async static Task SeedRoleAsync(IServiceProvider provider)
        {
            var roleManager = provider.GetService<RoleManager<IdentityRole>>();
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }
        }

        public async static Task SeedCities(PharmaciesDbContext context)
        {
            if (!context.Regions.Any())
            {
                var cities = new List<City>();
                var currentCity = new City { Name = "Велико Търново" };
                cities.Add(currentCity);
                cities.Add(new City { Name = "Горна Оряховица" });
                cities.Add(new City { Name = "Елена" });
                cities.Add(new City { Name = "Павликени" });
                cities.Add(new City { Name = "Полски Тръмбеш" });
                cities.Add(new City { Name = "Свищов" });
                cities.Add(new City { Name = "Златарица" });
                cities.Add(new City { Name = "Лясковец" });

                var region = new Pharmacies.Models.Region
                    {
                        Name = "Велико Търново",
                        Cities = cities
                    };
                    await context.Regions.AddAsync(region);
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw new Exception("Something wrong in PharmaciesDbContext");
                }
            }
        }
    }
}
