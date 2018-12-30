using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pharmacies.Models;
using Pharmacies.Web.Models;
using Pharmacies.Web.Models.PharmaciesViewModels;
using Pharmacies.Web.Services.Contracts;

namespace Pharmacies.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPharmaciesService pharmaciesService;

        private readonly SignInManager<PharmaciesUser> signIn;

        public HomeController(IPharmaciesService pharmaciesService, SignInManager<PharmaciesUser> signIn)
        {
            this.pharmaciesService = pharmaciesService;
            this.signIn = signIn;
        }

        public IActionResult Index(AllPharmaciesViewModel model)
        {
            var pharmacies = pharmaciesService.All();
            model = new AllPharmaciesViewModel { AllPharmacies = pharmacies.ToList() };

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
