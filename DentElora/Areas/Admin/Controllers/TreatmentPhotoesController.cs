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

namespace DentElora.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TreatmentPhotoesController : Controller
    {
        private readonly DatabaseContext _context;

        public TreatmentPhotoesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Admin/TreatmentPhotoes
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.TreatmentPhotos.Include(t => t.Treatment);
            return View(await databaseContext.ToListAsync());
        }

        // GET: Admin/TreatmentPhotoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatmentPhoto = await _context.TreatmentPhotos
                .Include(t => t.Treatment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (treatmentPhoto == null)
            {
                return NotFound();
            }

            return View(treatmentPhoto);
        }

        // GET: Admin/TreatmentPhotoes/Create
        public IActionResult Create()
        {
            ViewData["TreatmentId"] = new SelectList(_context.Treatments, "Id", "Title");
            return View();
        }

        // POST: Admin/TreatmentPhotoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image,Image2,TreatmentId")] TreatmentPhoto treatmentPhoto, IFormFile? Image, IFormFile? Image2)
        {
            if (ModelState.IsValid)
            {
                if (Image is not null) treatmentPhoto.Image = await FileHelper.FileLoaderAsync(Image);
                if (Image2 is not null) treatmentPhoto.Image2 = await FileHelper.FileLoaderAsync(Image2);
                _context.Add(treatmentPhoto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TreatmentId"] = new SelectList(_context.Treatments, "Id", "Title", treatmentPhoto.TreatmentId);
            return View(treatmentPhoto);
        }

        // GET: Admin/TreatmentPhotoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatmentPhoto = await _context.TreatmentPhotos.FindAsync(id);
            if (treatmentPhoto == null)
            {
                return NotFound();
            }
            ViewData["TreatmentId"] = new SelectList(_context.Treatments, "Id", "Title", treatmentPhoto.TreatmentId);
            return View(treatmentPhoto);
        }

        // POST: Admin/TreatmentPhotoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,Image2,TreatmentId")] TreatmentPhoto treatmentPhoto, IFormFile? Image, IFormFile? Image2)
        {
            if (id != treatmentPhoto.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {

                ViewData["TreatmentId"] = new SelectList(_context.Treatments, "Id", "Title", treatmentPhoto.TreatmentId);
                return View(treatmentPhoto);
            }

            // 1) Veritabanındaki var olan doktoru alın
            var dbGallery = await _context.TreatmentPhotos.FindAsync(id);
            if (dbGallery == null)
                return NotFound();

            //

            // 3) Eğer yeni bir resim yüklenmişse, yeni yolunu ata; yoksa hiçbir değişiklik yapma
            if (Image is not null)
            {
                dbGallery.Image = await FileHelper.FileLoaderAsync(Image);
            }
            if (Image2 is not null)
            {
                dbGallery.Image2 = await FileHelper.FileLoaderAsync(Image2);
            }

            // 4) Kaydet
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
        }

        // GET: Admin/TreatmentPhotoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatmentPhoto = await _context.TreatmentPhotos
                .Include(t => t.Treatment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (treatmentPhoto == null)
            {
                return NotFound();
            }

            return View(treatmentPhoto);
        }

        // POST: Admin/TreatmentPhotoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var treatmentPhoto = await _context.TreatmentPhotos.FindAsync(id);
            if (treatmentPhoto != null)
            {
                _context.TreatmentPhotos.Remove(treatmentPhoto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreatmentPhotoExists(int id)
        {
            return _context.TreatmentPhotos.Any(e => e.Id == id);
        }
    }
}
