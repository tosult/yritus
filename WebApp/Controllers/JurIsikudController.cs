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
    public class JurIsikudController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JurIsikudController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JurIsikud
        public async Task<IActionResult> Index()
        {
            return View(await _context.JurIsikud.ToListAsync());
        }

        // GET: JurIsikud/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jurIsik = await _context.JurIsikud
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jurIsik == null)
            {
                return NotFound();
            }

            return View(jurIsik);
        }

        // GET: JurIsikud/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JurIsikud/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OsavotumaksId,JurIsikLiikId,Nimi,Registrikood,Lisainfo,Id")] JurIsik jurIsik)
        {
            if (ModelState.IsValid)
            {
                jurIsik.Id = Guid.NewGuid();
                _context.Add(jurIsik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jurIsik);
        }

        // GET: JurIsikud/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jurIsik = await _context.JurIsikud.FindAsync(id);
            if (jurIsik == null)
            {
                return NotFound();
            }
            return View(jurIsik);
        }

        // POST: JurIsikud/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("OsavotumaksId,JurIsikLiikId,Nimi,Registrikood,Lisainfo,Id")] JurIsik jurIsik)
        {
            if (id != jurIsik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jurIsik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JurIsikExists(jurIsik.Id))
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
            return View(jurIsik);
        }

        // GET: JurIsikud/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jurIsik = await _context.JurIsikud
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jurIsik == null)
            {
                return NotFound();
            }

            return View(jurIsik);
        }

        // POST: JurIsikud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var jurIsik = await _context.JurIsikud.FindAsync(id);
            if (jurIsik != null)
            {
                _context.JurIsikud.Remove(jurIsik);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JurIsikExists(Guid id)
        {
            return _context.JurIsikud.Any(e => e.Id == id);
        }
    }
}
