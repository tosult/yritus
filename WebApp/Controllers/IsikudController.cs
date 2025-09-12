using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Contracts.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.EF.App;
using Domain.App;

namespace WebApp.Controllers
{
    public class IsikudController : Controller
    {
        private readonly IAppUOW _uow;

        public IsikudController(IAppUOW uow)
        {
            _uow = uow;
        }

        // GET: Isikud
        public async Task<IActionResult> Index()
        {
            var vm = await _uow.IsikRepository.AllAsync();
            return View(vm);
        }

        // GET: Isikud/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isik = await _uow.IsikRepository
                .FindAsync(id.Value);
            if (isik == null)
            {
                return NotFound();
            }

            return View(isik);
        }

        // GET: Isikud/Create
        public async Task<IActionResult> Create()
        {
            ViewData["OsavotumaksId"] = new SelectList(await _uow.OsavotumaksRepository.AllAsync(), "Id", "Name");
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
                var defaultStaatusId = _uow.OsavotumaksuStaatusRepository
                    .AllAsync()
                    .Result
                    .FirstOrDefault(i => !i.Staatus)
                    .Id;

                var defaultViisId = _uow.TasumiseViisRepository
                    .AllAsync()
                    .Result
                    .FirstOrDefault(i => i.ViisNimetus == "Sularaha")
                    .Id;
                
                var guidOsavotumaks = Guid.NewGuid();
                var osavotumaks = new Osavotumaks()
                {
                    Id = guidOsavotumaks,
                    OsavotumaksuStaatusId = defaultStaatusId,
                    TasumiseViisId = defaultViisId
                };
                
                _uow.OsavotumaksRepository.Add(osavotumaks);
                isik.Id = Guid.NewGuid();
                isik.OsavotumaksId = guidOsavotumaks;
                _uow.IsikRepository.Add(isik);
                
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OsavotumaksId"] = new SelectList(await _uow.OsavotumaksRepository.AllAsync(), "Id", "Id", isik.OsavotumaksId);
            return View(isik);
        }

        // GET: Isikud/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isik = await _uow.IsikRepository.FindAsync(id.Value);
            if (isik == null)
            {
                return NotFound();
            }
            ViewData["OsavotumaksId"] = new SelectList(await _uow.OsavotumaksRepository.AllAsync(), "Id", "Id", isik.OsavotumaksId);
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
                    _uow.IsikRepository.Update(isik);
                    await _uow.SaveChangesAsync();
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
            ViewData["OsavotumaksId"] = new SelectList(await _uow.OsavotumaksRepository.AllAsync(), "Id", "Id", isik.OsavotumaksId);
            return View(isik);
        }

        // GET: Isikud/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isik = await _uow.IsikRepository.FindAsync(id.Value);
            
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
            await _uow.IsikRepository.RemoveAsync(id);
            
            await _uow.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        private bool IsikExists(Guid id)
        {
            return (_uow.IsikRepository?.FindAsync(id) == null);
        }
    }
}
