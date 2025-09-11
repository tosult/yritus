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
    public class IsikudController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IsikudController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Isikud
        public async Task<IActionResult> Index()
        {
            return View(await _context.Isikud.ToListAsync());
        }

        // GET: Isikud/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isik = await _context.Isikud
                .FirstOrDefaultAsync(m => m.Id == id);
            if (isik == null)
            {
                return NotFound();
            }

            return View(isik);
        }

        // GET: Isikud/Create
        public IActionResult Create()
        {
            ViewData["OsavotumaksId"] = new SelectList(_context.Osavotumaksud, "Id", "Id");
            return View();
        }

        // POST: Isikud/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Eesnimi,Perenimi,Isikukood,Lisainfo,Id")] Isik isik)
        {
            if (ModelState.IsValid)
            {
                var defaultStaatusId = _context.OsavotumaksuStaatused
                    .Where(s => s.Staatus == false)
                    .Select(s => s.Id)
                    .FirstOrDefault();
                
                
                var defaultViisId = _context.TasumiseViisid
                    .Where(s => s.ViisNimetus == "Sularaha")
                    .Select(s => s.Id)
                    .FirstOrDefault();
                
                var guidOsavotumaks = Guid.NewGuid();
                var osavotumaks = new Osavotumaks()
                {
                    Id = guidOsavotumaks,
                    OsavotumaksuStaatusId = defaultStaatusId,
                    TasumiseViisId = defaultViisId
                };
                _context.Add(osavotumaks);
                isik.Id = Guid.NewGuid();
                isik.OsavotumaksId = guidOsavotumaks;
                _context.Add(isik);
                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OsavotumaksId"] = new SelectList(_context.Osavotumaksud, "Id", "Id", isik.OsavotumaksId);
            return View(isik);
        }

        // GET: Isikud/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isik = await _context.Isikud.FindAsync(id);
            if (isik == null)
            {
                return NotFound();
            }
            ViewData["OsavotumaksId"] = new SelectList(_context.Osavotumaksud, "Id", "Id", isik.OsavotumaksId);
            return View(isik);
        }

        // POST: Isikud/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("OsavotumaksId, Eesnimi,Perenimi,Isikukood,Lisainfo,Id")] Isik isik)
        {
            if (id != isik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(isik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IsikExists(isik.Id))
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
            ViewData["OsavotumaksId"] = new SelectList(_context.Osavotumaksud, "Id", "Id", isik.OsavotumaksId);
            return View(isik);
        }

        // GET: Isikud/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isik = await _context.Isikud
                .FirstOrDefaultAsync(m => m.Id == id);
            if (isik == null)
            {
                return NotFound();
            }

            return View(isik);
        }

        // POST: Isikud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var isik = await _context.Isikud.FindAsync(id);
            if (isik != null)
            {
                _context.Isikud.Remove(isik);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IsikExists(Guid id)
        {
            return _context.Isikud.Any(e => e.Id == id);
        }
    }
}
