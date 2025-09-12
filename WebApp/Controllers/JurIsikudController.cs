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
    public class JurIsikudController : Controller
    {
        private readonly IAppUOW _uow;

        public JurIsikudController(IAppUOW uow)
        {
            _uow = uow;
        }

        // GET: JurIsikud
        public async Task<IActionResult> Index()
        {
            var vm = await _uow.JurIsikRepository.AllAsync();
            return View(vm);
        }

        // GET: JurIsikud/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jurIsik = await _uow.JurIsikRepository
                .FindAsync(id.Value);
            
            if (jurIsik == null)
            {
                return NotFound();
            }

            return View(jurIsik);
        }

        // GET: JurIsikud/Create
        public async Task<IActionResult> Create()
        {
            ViewData["OsavotumaksId"] = new SelectList(await _uow.OsavotumaksRepository.AllAsync(), "Id", "Id");
            ViewData["JurIsikLiikId"] = new SelectList(await _uow.JurIsikLiikRepository.AllAsync(), "Id", "LiikNimetus");
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
                _uow.JurIsikRepository.Add(jurIsik);
                await _uow.SaveChangesAsync();
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

            var jurIsik = await _uow.JurIsikRepository.FindAsync(id.Value);
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
                    _uow.JurIsikRepository.Update(jurIsik);
                    await _uow.SaveChangesAsync();
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

            var jurIsik = await _uow.JurIsikRepository.FindAsync(id.Value);
                
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
            await _uow.JurIsikRepository.RemoveAsync(id);
            
            await _uow.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        private bool JurIsikExists(Guid id)
        {
            return (_uow.JurIsikRepository?.FindAsync(id) == null);
        }
    }
}
