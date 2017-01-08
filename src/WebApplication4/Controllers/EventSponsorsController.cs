using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication4.Controllers
{
    public class EventSponsorsController : Controller
    {
        private readonly EventsDbContext _context;

        public EventSponsorsController(EventsDbContext context)
        {
            _context = context;    
        }

        // GET: EventSponsors
        public async Task<IActionResult> Index()
        {
            var eventsDbContext = _context.EventSponsors.Include(e => e.Event).Include(e => e.Sponsor);
            return View(await eventsDbContext.ToListAsync());
        }

        // GET: EventSponsors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventSponsor = await _context.EventSponsors.SingleOrDefaultAsync(m => m.EventSponsorID == id);
            if (eventSponsor == null)
            {
                return NotFound();
            }

            return View(eventSponsor);
        }

        // GET: EventSponsors/Create
        public IActionResult Create()
        {
            ViewData["EventID"] = new SelectList(_context.Events, "ID", "ID");
            ViewData["SponsorID"] = new SelectList(_context.Sponsors, "ID", "ID");
            return View();
        }

        // POST: EventSponsors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventSponsorID,EventID,SponsorID")] EventSponsor eventSponsor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventSponsor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["EventID"] = new SelectList(_context.Events, "ID", "ID", eventSponsor.EventID);
            ViewData["SponsorID"] = new SelectList(_context.Sponsors, "ID", "ID", eventSponsor.SponsorID);
            return View(eventSponsor);
        }

        // GET: EventSponsors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventSponsor = await _context.EventSponsors.SingleOrDefaultAsync(m => m.EventSponsorID == id);
            if (eventSponsor == null)
            {
                return NotFound();
            }
            ViewData["EventID"] = new SelectList(_context.Events, "ID", "ID", eventSponsor.EventID);
            ViewData["SponsorID"] = new SelectList(_context.Sponsors, "ID", "ID", eventSponsor.SponsorID);
            return View(eventSponsor);
        }

        // POST: EventSponsors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventSponsorID,EventID,SponsorID")] EventSponsor eventSponsor)
        {
            if (id != eventSponsor.EventSponsorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventSponsor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventSponsorExists(eventSponsor.EventSponsorID))
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
            ViewData["EventID"] = new SelectList(_context.Events, "ID", "ID", eventSponsor.EventID);
            ViewData["SponsorID"] = new SelectList(_context.Sponsors, "ID", "ID", eventSponsor.SponsorID);
            return View(eventSponsor);
        }

        // GET: EventSponsors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventSponsor = await _context.EventSponsors.SingleOrDefaultAsync(m => m.EventSponsorID == id);
            if (eventSponsor == null)
            {
                return NotFound();
            }

            return View(eventSponsor);
        }

        // POST: EventSponsors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventSponsor = await _context.EventSponsors.SingleOrDefaultAsync(m => m.EventSponsorID == id);
            _context.EventSponsors.Remove(eventSponsor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EventSponsorExists(int id)
        {
            return _context.EventSponsors.Any(e => e.EventSponsorID == id);
        }
    }
}
