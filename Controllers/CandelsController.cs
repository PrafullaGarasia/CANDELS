using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcCandel.Data;
using MvcCandel.Models;

namespace MvcCandel.Controllers
{
    public class CandelsController : Controller
    {
        private readonly MvcCandelContext _context;

        public CandelsController(MvcCandelContext context)
        {
            _context = context;
        }

        // GET: Candels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Candel.ToListAsync());
        }

        // GET: Candels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candel = await _context.Candel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candel == null)
            {
                return NotFound();
            }

            return View(candel);
        }

        // GET: Candels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Candels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Color,MadeFrom,Fragrance,ExpiryDate,Price")] Candel candel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(candel);
        }

        // GET: Candels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candel = await _context.Candel.FindAsync(id);
            if (candel == null)
            {
                return NotFound();
            }
            return View(candel);
        }

        // POST: Candels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Color,MadeFrom,Fragrance,ExpiryDate,Price")] Candel candel)
        {
            if (id != candel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandelExists(candel.Id))
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
            return View(candel);
        }

        // GET: Candels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candel = await _context.Candel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candel == null)
            {
                return NotFound();
            }

            return View(candel);
        }

        // POST: Candels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candel = await _context.Candel.FindAsync(id);
            _context.Candel.Remove(candel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandelExists(int id)
        {
            return _context.Candel.Any(e => e.Id == id);
        }
    }
}
