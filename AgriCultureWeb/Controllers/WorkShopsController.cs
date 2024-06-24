using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgriCultureWeb.Data;
using AgriCultureWeb.Models;

namespace AgriCultureWeb.Controllers
{
    public class WorkShopsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkShopsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WorkShops
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkShops.ToListAsync());
        }

        // GET: WorkShops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workShop = await _context.WorkShops
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workShop == null)
            {
                return NotFound();
            }

            return View(workShop);
        }

        // GET: WorkShops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkShops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] WorkShop workShop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workShop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workShop);
        }

        // GET: WorkShops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workShop = await _context.WorkShops.FindAsync(id);
            if (workShop == null)
            {
                return NotFound();
            }
            return View(workShop);
        }

        // POST: WorkShops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] WorkShop workShop)
        {
            if (id != workShop.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workShop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkShopExists(workShop.Id))
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
            return View(workShop);
        }

        // GET: WorkShops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workShop = await _context.WorkShops
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workShop == null)
            {
                return NotFound();
            }

            return View(workShop);
        }

        // POST: WorkShops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workShop = await _context.WorkShops.FindAsync(id);
            if (workShop != null)
            {
                _context.WorkShops.Remove(workShop);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkShopExists(int id)
        {
            return _context.WorkShops.Any(e => e.Id == id);
        }
    }
}
