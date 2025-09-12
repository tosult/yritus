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
    public class TasumiseViisidController : Controller
    {
        private readonly IAppUOW _uow;

        public TasumiseViisidController(IAppUOW uow)
        {
            _uow = uow;
        }

        // GET: TasumiseViisid
        public async Task<IActionResult> Index()
        {
            var vm = await _uow.TasumiseViisRepository.AllAsync();
            return View(vm);
        }

        // GET: TasumiseViisid/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasumiseViis = await _uow.TasumiseViisRepository
                .FindAsync(id.Value);
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
                _uow.TasumiseViisRepository.Add(tasumiseViis);
                await _uow.SaveChangesAsync();
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

            var tasumiseViis = await _uow.TasumiseViisRepository.FindAsync(id.Value);
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
                    _uow.TasumiseViisRepository.Update(tasumiseViis);
                    await _uow.SaveChangesAsync();
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

            var tasumiseViis = await _uow.TasumiseViisRepository.FindAsync(id.Value);
            
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
            await _uow.TasumiseViisRepository.RemoveAsync(id);
            
            await _uow.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        private bool TasumiseViisExists(Guid id)
        {
            return (_uow.TasumiseViisRepository?.FindAsync(id) == null);
        }
    }
}
