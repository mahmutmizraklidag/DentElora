using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DentElora.Data;
using DentElora.Entities;

namespace DentElora.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeInfoesController : Controller
    {
        private readonly DatabaseContext _context;

        public HomeInfoesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Admin/HomeInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.HomeInfos.ToListAsync());
        }

        // GET: Admin/HomeInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeInfo = await _context.HomeInfos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homeInfo == null)
            {
                return NotFound();
            }

            return View(homeInfo);
        }

        // GET: Admin/HomeInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/HomeInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Icon")] HomeInfo homeInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(homeInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(homeInfo);
        }

        // GET: Admin/HomeInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeInfo = await _context.HomeInfos.FindAsync(id);
            if (homeInfo == null)
            {
                return NotFound();
            }
            return View(homeInfo);
        }

        // POST: Admin/HomeInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Icon")] HomeInfo homeInfo)
        {
            if (id != homeInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(homeInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeInfoExists(homeInfo.Id))
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
            return View(homeInfo);
        }

        // GET: Admin/HomeInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeInfo = await _context.HomeInfos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homeInfo == null)
            {
                return NotFound();
            }

            return View(homeInfo);
        }

        // POST: Admin/HomeInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var homeInfo = await _context.HomeInfos.FindAsync(id);
            if (homeInfo != null)
            {
                _context.HomeInfos.Remove(homeInfo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeInfoExists(int id)
        {
            return _context.HomeInfos.Any(e => e.Id == id);
        }
    }
}
