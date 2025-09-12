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
    public class YritusedController : Controller
    {
        private readonly IAppUOW _uow;

        public YritusedController(IAppUOW uow)
        {
            _uow = uow;
        }
        
        // GET: Yritused
        public async Task<IActionResult> Index()
        {
            var vm = await _uow.YritusRepository.AllAsync();
            return View(vm);
        }

        // GET: Yritused/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yritus = await _uow.YritusRepository
                .FindAsync(id.Value);
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
                _uow.YritusRepository.Add(yritus);
                await _uow.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
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

            var yritus = await _uow.YritusRepository.FindAsync(id.Value);
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
                    _uow.YritusRepository.Update(yritus);
                    await _uow.SaveChangesAsync();
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
                return RedirectToAction("Index", "Home");
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

            var yritus = await _uow.YritusRepository.FindAsync(id.Value);
            
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
            await _uow.YritusRepository.RemoveAsync(id);
            
            await _uow.SaveChangesAsync();
            
            return RedirectToAction("Index", "Home");
        }

        private bool YritusExists(Guid id)
        {
            return (_uow.YritusRepository?.FindAsync(id) == null);
        }
    }
}
