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
    public class GalleriesController : Controller
    {
        private readonly DatabaseContext _context;

        public GalleriesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Admin/Galleries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Galleries.ToListAsync());
        }

        // GET: Admin/Galleries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gallery = await _context.Galleries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gallery == null)
            {
                return NotFound();
            }

            return View(gallery);
        }

        // GET: Admin/Galleries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Galleries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image,isActive")] Gallery gallery, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                if (Image is not null) gallery.Image = await FileHelper.FileLoaderAsync(Image);
                _context.Add(gallery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gallery);
        }

        // GET: Admin/Galleries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gallery = await _context.Galleries.FindAsync(id);
            if (gallery == null)
            {
                return NotFound();
            }
            return View(gallery);
        }

        // POST: Admin/Galleries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,isActive")] Gallery gallery, IFormFile? Image)
        {
            if (id != gallery.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(gallery);

            // 1) Veritabanındaki var olan doktoru alın
            var dbGallery = await _context.Galleries.FindAsync(id);
            if (dbGallery == null)
                return NotFound();

            // 2) Sadece güncellenen alanı ata
            dbGallery.isActive = gallery.isActive;

            // 3) Eğer yeni bir resim yüklenmişse, yeni yolunu ata; yoksa hiçbir değişiklik yapma
            if (Image is not null)
            {
                dbGallery.Image = await FileHelper.FileLoaderAsync(Image);
            }

            // 4) Kaydet
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Galleries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gallery = await _context.Galleries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gallery == null)
            {
                return NotFound();
            }

            return View(gallery);
        }

        // POST: Admin/Galleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gallery = await _context.Galleries.FindAsync(id);
            if (gallery != null)
            {
                _context.Galleries.Remove(gallery);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GalleryExists(int id)
        {
            return _context.Galleries.Any(e => e.Id == id);
        }
    }
}
