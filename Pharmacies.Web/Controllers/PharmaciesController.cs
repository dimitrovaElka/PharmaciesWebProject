using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pharmacies.Data;
using Pharmacies.Models;

namespace Pharmacies.Web.Controllers
{
    public class PharmaciesController : Controller
    {
        private readonly PharmaciesDbContext _context;

        public PharmaciesController(PharmaciesDbContext context)
        {
            _context = context;
        }

        // GET: Pharmacies
        public async Task<IActionResult> Index()
        {
            var pharmaciesDbContext = _context.Pharmacies.Include(p => p.City);
            return View(await pharmaciesDbContext.ToListAsync());
        }

        // GET: Pharmacies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmacy = await _context.Pharmacies
                .Include(p => p.City)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pharmacy == null)
            {
                return NotFound();
            }

            return View(pharmacy);
        }

        // GET: Pharmacies/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id");
            return View();
        }

        // POST: Pharmacies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Eik,PharmacyLicense,DrugsLicense,CityId,Address,Manager,Telefon,Email")] Pharmacy pharmacy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pharmacy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", pharmacy.CityId);
            return View(pharmacy);
        }

        // GET: Pharmacies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmacy = await _context.Pharmacies.FindAsync(id);
            if (pharmacy == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", pharmacy.CityId);
            return View(pharmacy);
        }

        // POST: Pharmacies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Eik,PharmacyLicense,DrugsLicense,CityId,Address,Manager,Telefon,Email")] Pharmacy pharmacy)
        {
            if (id != pharmacy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pharmacy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PharmacyExists(pharmacy.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", pharmacy.CityId);
            return View(pharmacy);
        }

        // GET: Pharmacies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmacy = await _context.Pharmacies
                .Include(p => p.City)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pharmacy == null)
            {
                return NotFound();
            }

            return View(pharmacy);
        }

        // POST: Pharmacies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pharmacy = await _context.Pharmacies.FindAsync(id);
            _context.Pharmacies.Remove(pharmacy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PharmacyExists(int id)
        {
            return _context.Pharmacies.Any(e => e.Id == id);
        }
    }
}
