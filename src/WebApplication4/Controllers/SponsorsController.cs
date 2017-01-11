using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication4.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class SponsorsController : Controller
    {
        private readonly EventsDbContext _context;

        public SponsorsController(EventsDbContext context)
        {
            _context = context;    
        }

        // GET: Sponsors
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var sponsors = from s in _context.Sponsors
                           select s;
            switch (sortOrder)
            {
                case "name_desc":
                    sponsors = sponsors.OrderByDescending(s => s.Name);
                    break;
                default:
                    sponsors = sponsors.OrderBy(s => s.Name);
                    break;
            }
            return View(await sponsors.AsNoTracking().ToListAsync());
        }

        // GET: Sponsors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sponsor = await _context.Sponsors.SingleOrDefaultAsync(m => m.ID == id);
            if (sponsor == null)
            {
                return NotFound();
            }

            return View(sponsor);
        }

        // GET: Sponsors/Create
        public IActionResult Create()
        {
            ViewData["BranchID"] = new SelectList(_context.Branches, "ID", "ID");
            return View();
        }

        // POST: Sponsors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,About,BranchID,Name,Nip,Regon")] Sponsor sponsor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sponsor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["BranchID"] = new SelectList(_context.Branches, "ID", "ID", sponsor.BranchID);
            return View(sponsor);
        }

        // GET: Sponsors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sponsor = await _context.Sponsors.SingleOrDefaultAsync(m => m.ID == id);
            if (sponsor == null)
            {
                return NotFound();
            }
            ViewData["BranchID"] = new SelectList(_context.Branches, "ID", "ID", sponsor.BranchID);
            return View(sponsor);
        }

        // POST: Sponsors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,About,BranchID,Name,Nip,Regon")] Sponsor sponsor)
        {
            if (id != sponsor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sponsor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SponsorExists(sponsor.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["BranchID"] = new SelectList(_context.Branches, "ID", "ID", sponsor.BranchID);
            return View(sponsor);
        }

        // GET: Sponsors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sponsor = await _context.Sponsors.SingleOrDefaultAsync(m => m.ID == id);
            if (sponsor == null)
            {
                return NotFound();
            }

            return View(sponsor);
        }

        // POST: Sponsors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sponsor = await _context.Sponsors.SingleOrDefaultAsync(m => m.ID == id);
            _context.Sponsors.Remove(sponsor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SponsorExists(int id)
        {
            return _context.Sponsors.Any(e => e.ID == id);
        }
    }
}
