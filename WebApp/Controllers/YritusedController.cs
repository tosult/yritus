using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.EF.App;
using Domain.App;

namespace WebApp.Controllers
{
    public class YritusedController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YritusedController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Yritused/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yritus = await _context.Yritused
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yritus == null)
            {
                return NotFound();
            }

            return View(yritus);
        }

        // GET: Yritused/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yritused/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nimi,Algus,Lopp,Asukoht,Id")] Yritus yritus)
        {
            if (ModelState.IsValid)
            {
                yritus.Id = Guid.NewGuid();
                _context.Add(yritus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(HomeController.Index));
            }
            return View(yritus);
        }

        // GET: Yritused/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yritus = await _context.Yritused.FindAsync(id);
            if (yritus == null)
            {
                return NotFound();
            }
            return View(yritus);
        }

        // POST: Yritused/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Nimi,Algus,Lopp,Asukoht,Id")] Yritus yritus)
        {
            if (id != yritus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yritus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YritusExists(yritus.Id))
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
            return View(yritus);
        }

        // GET: Yritused/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yritus = await _context.Yritused
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yritus == null)
            {
                return NotFound();
            }

            return View(yritus);
        }

        // POST: Yritused/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var yritus = await _context.Yritused.FindAsync(id);
            if (yritus != null)
            {
                _context.Yritused.Remove(yritus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YritusExists(Guid id)
        {
            return _context.Yritused.Any(e => e.Id == id);
        }
    }
}
