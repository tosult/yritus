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
    public class IsikudYrituselController : Controller
    {
        private readonly IAppUOW _uow;

        public IsikudYrituselController(IAppUOW uow)
        {
            _uow = uow;
        }

        // GET: IsikudYritusel
        public async Task<IActionResult> Index()
        {
            var vm = await _uow.IsikYrituselRepository.AllAsync();
            return View(vm);
        }

        // GET: IsikudYritusel/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isikYritusel = await _uow.IsikYrituselRepository
                .FindAsync(id.Value);
            
            if (isikYritusel == null)
            {
                return NotFound();
            }

            return View(isikYritusel);
        }

        // GET: IsikudYritusel/Create
        public async Task<IActionResult> Create()
        {
            ViewData["IsikId"] = new SelectList(await _uow.IsikRepository.AllAsync(), "Id", "Eesnimi");
            ViewData["JurIsikId"] = new SelectList(await _uow.JurIsikRepository.AllAsync(), "Id", "Nimi");
            ViewData["YritusId"] = new SelectList(await _uow.YritusRepository.AllAsync(), "Id", "Asukoht");
            return View();
        }

        // POST: IsikudYritusel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YritusId,IsikId,JurIsikId,Id")] IsikYritusel isikYritusel)
        {
            if (ModelState.IsValid)
            {
                isikYritusel.Id = Guid.NewGuid();
                _uow.IsikYrituselRepository.Add(isikYritusel);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IsikId"] = new SelectList(await _uow.IsikRepository.AllAsync(), "Id", "Eesnimi");
            ViewData["JurIsikId"] = new SelectList(await _uow.JurIsikRepository.AllAsync(), "Id", "Nimi");
            ViewData["YritusId"] = new SelectList(await _uow.YritusRepository.AllAsync(), "Id", "Asukoht");
            return View(isikYritusel);
        }

        // GET: IsikudYritusel/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isikYritusel = await _uow.IsikYrituselRepository.FindAsync(id.Value);
            if (isikYritusel == null)
            {
                return NotFound();
            }
            ViewData["IsikId"] = new SelectList(await _uow.IsikRepository.AllAsync(), "Id", "Eesnimi");
            ViewData["JurIsikId"] = new SelectList(await _uow.JurIsikRepository.AllAsync(), "Id", "Nimi");
            ViewData["YritusId"] = new SelectList(await _uow.YritusRepository.AllAsync(), "Id", "Asukoht");
            return View(isikYritusel);
        }

        // POST: IsikudYritusel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("YritusId,IsikId,JurIsikId,Id")] IsikYritusel isikYritusel)
        {
            if (id != isikYritusel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.IsikYrituselRepository.Update(isikYritusel);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IsikYrituselExists(isikYritusel.Id))
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
            ViewData["IsikId"] = new SelectList(await _uow.IsikRepository.AllAsync(), "Id", "Eesnimi");
            ViewData["JurIsikId"] = new SelectList(await _uow.JurIsikRepository.AllAsync(), "Id", "Nimi");
            ViewData["YritusId"] = new SelectList(await _uow.YritusRepository.AllAsync(), "Id", "Asukoht");
            return View(isikYritusel);
        }

        // GET: IsikudYritusel/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isikYritusel = await _uow.IsikYrituselRepository.FindAsync(id.Value);
            if (isikYritusel == null)
            {
                return NotFound();
            }

            return View(isikYritusel);
        }

        // POST: IsikudYritusel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.IsikYrituselRepository.RemoveAsync(id);
            
            await _uow.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        private bool IsikYrituselExists(Guid id)
        {
            return (_uow.IsikYrituselRepository?.FindAsync(id) == null);
        }
    }
}
