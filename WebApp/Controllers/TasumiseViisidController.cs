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
    public class TasumiseViisidController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TasumiseViisidController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TasumiseViisid
        public async Task<IActionResult> Index()
        {
            return View(await _context.TasumiseViisid.ToListAsync());
        }

        // GET: TasumiseViisid/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasumiseViis = await _context.TasumiseViisid
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tasumiseViis == null)
            {
                return NotFound();
            }

            return View(tasumiseViis);
        }

        // GET: TasumiseViisid/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TasumiseViisid/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ViisNimetus,Id")] TasumiseViis tasumiseViis)
        {
            if (ModelState.IsValid)
            {
                tasumiseViis.Id = Guid.NewGuid();
                _context.Add(tasumiseViis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tasumiseViis);
        }

        // GET: TasumiseViisid/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasumiseViis = await _context.TasumiseViisid.FindAsync(id);
            if (tasumiseViis == null)
            {
                return NotFound();
            }
            return View(tasumiseViis);
        }

        // POST: TasumiseViisid/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ViisNimetus,Id")] TasumiseViis tasumiseViis)
        {
            if (id != tasumiseViis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tasumiseViis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TasumiseViisExists(tasumiseViis.Id))
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
            return View(tasumiseViis);
        }

        // GET: TasumiseViisid/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasumiseViis = await _context.TasumiseViisid
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tasumiseViis == null)
            {
                return NotFound();
            }

            return View(tasumiseViis);
        }

        // POST: TasumiseViisid/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tasumiseViis = await _context.TasumiseViisid.FindAsync(id);
            if (tasumiseViis != null)
            {
                _context.TasumiseViisid.Remove(tasumiseViis);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TasumiseViisExists(Guid id)
        {
            return _context.TasumiseViisid.Any(e => e.Id == id);
        }
    }
}
