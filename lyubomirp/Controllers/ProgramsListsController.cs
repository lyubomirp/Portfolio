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
    public class ProgramsListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProgramsListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProgramsLists
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProgramsList.ToListAsync());
        }

        // GET: ProgramsLists/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programsList = await _context.ProgramsList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (programsList == null)
            {
                return NotFound();
            }

            return View(programsList);
        }

        // GET: ProgramsLists/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProgramsLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,programsAndIDEs")] ProgramsList programsList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programsList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(programsList);
        }

        // GET: ProgramsLists/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programsList = await _context.ProgramsList.FindAsync(id);
            if (programsList == null)
            {
                return NotFound();
            }
            return View(programsList);
        }

        // POST: ProgramsLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,programsAndIDEs")] ProgramsList programsList)
        {
            if (id != programsList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programsList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramsListExists(programsList.Id))
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
            return View(programsList);
        }

        // GET: ProgramsLists/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programsList = await _context.ProgramsList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (programsList == null)
            {
                return NotFound();
            }

            return View(programsList);
        }

        // POST: ProgramsLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programsList = await _context.ProgramsList.FindAsync(id);
            _context.ProgramsList.Remove(programsList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramsListExists(int id)
        {
            return _context.ProgramsList.Any(e => e.Id == id);
        }
    }
}
