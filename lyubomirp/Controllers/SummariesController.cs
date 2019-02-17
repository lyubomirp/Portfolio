using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using identity.Data;
using lyubomirp.Models;
using Microsoft.AspNetCore.Authorization;

namespace lyubomirp.Controllers
{
    public class SummariesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SummariesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Summaries
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Summary.ToListAsync());
        }

        // GET: Summaries/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var summary = await _context.Summary
                .FirstOrDefaultAsync(m => m.Id == id);
            if (summary == null)
            {
                return NotFound();
            }

            return View(summary);
        }

        // GET: Summaries/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Summaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,mainContent,technologies,programsAndIDEs")] Summary summary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(summary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(summary);
        }

        // GET: Summaries/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var summary = await _context.Summary.FindAsync(id);
            if (summary == null)
            {
                return NotFound();
            }
            return View(summary);
        }

        // POST: Summaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,mainContent,technologies,programsAndIDEs")] Summary summary)
        {
            if (id != summary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(summary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SummaryExists(summary.Id))
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
            return View(summary);
        }

        // GET: Summaries/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var summary = await _context.Summary
                .FirstOrDefaultAsync(m => m.Id == id);
            if (summary == null)
            {
                return NotFound();
            }

            return View(summary);
        }

        // POST: Summaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var summary = await _context.Summary.FindAsync(id);
            _context.Summary.Remove(summary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SummaryExists(int id)
        {
            return _context.Summary.Any(e => e.Id == id);
        }
    }
}
