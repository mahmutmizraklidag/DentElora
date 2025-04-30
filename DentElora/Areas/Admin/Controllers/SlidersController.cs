using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DentElora.Data;
using DentElora.Entities;
using DentElora.Utils;
using System.Numerics;

namespace DentElora.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlidersController : Controller
    {
        private readonly DatabaseContext _context;

        public SlidersController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Admin/Sliders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sliders.ToListAsync());
        }

        // GET: Admin/Sliders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slider = await _context.Sliders
                .FirstOrDefaultAsync(m => m.id == id);
            if (slider == null)
            {
                return NotFound();
            }

            return View(slider);
        }

        // GET: Admin/Sliders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sliders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,image,image2,Description")] Slider slider, IFormFile? image, IFormFile? image2)
        {
            if (ModelState.IsValid)
            {
                if (image is not null) slider.image = await FileHelper.FileLoaderAsync(image);
                if (image2 is not null) slider.image2 = await FileHelper.FileLoaderAsync(image2);
                _context.Add(slider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(slider);
        }

        // GET: Admin/Sliders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slider = await _context.Sliders.FindAsync(id);
            if (slider == null)
            {
                return NotFound();
            }
            return View(slider);
        }

        // POST: Admin/Sliders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,image,image2,Description")] Slider slider, IFormFile? image, IFormFile? image2)
        {
            if (id != slider.id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(slider);

            // 1) Veritabanındaki var olan doktoru alın
            var dbGallery = await _context.Sliders.FindAsync(id);
            if (dbGallery == null)
                return NotFound();

            // 2) Sadece güncellenen alanı ata
            dbGallery.Description = slider.Description;

            // 3) Eğer yeni bir resim yüklenmişse, yeni yolunu ata; yoksa hiçbir değişiklik yapma
            if (image is not null)
            {
                dbGallery.image = await FileHelper.FileLoaderAsync(image);
            }
            if (image2 is not null)
            {
                dbGallery.image2 = await FileHelper.FileLoaderAsync(image2);
            }

            // 4) Kaydet
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Sliders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slider = await _context.Sliders
                .FirstOrDefaultAsync(m => m.id == id);
            if (slider == null)
            {
                return NotFound();
            }

            return View(slider);
        }

        // POST: Admin/Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            if (slider != null)
            {
                _context.Sliders.Remove(slider);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SliderExists(int id)
        {
            return _context.Sliders.Any(e => e.id == id);
        }
    }
}
