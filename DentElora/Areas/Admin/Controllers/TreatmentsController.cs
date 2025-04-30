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
    public class TreatmentsController : Controller
    {
        private readonly DatabaseContext _context;

        public TreatmentsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Admin/Treatments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Treatments.ToListAsync());
        }

        // GET: Admin/Treatments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatment = await _context.Treatments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (treatment == null)
            {
                return NotFound();
            }

            return View(treatment);
        }

        // GET: Admin/Treatments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Treatments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Treatment treatment,IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                if (Image is not null) treatment.Image = await FileHelper.FileLoaderAsync(Image);
                _context.Add(treatment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(treatment);
        }

        // GET: Admin/Treatments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatment = await _context.Treatments.FindAsync(id);
            if (treatment == null)
            {
                return NotFound();
            }
            return View(treatment);
        }

        // POST: Admin/Treatments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Treatment treatment,IFormFile? Image)
        {
            if (id != treatment.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(treatment);

            // 1) Veritabanındaki var olan doktoru alın
            var dbTreatment = await _context.Treatments.FindAsync(id);
            if (dbTreatment == null)
                return NotFound();

            // 2) Sadece güncellenen alanı ata
            dbTreatment.Title = treatment.Title;
            dbTreatment.shortDescription = treatment.shortDescription;
            dbTreatment.Description = treatment.Description;
            dbTreatment.İcon = treatment.İcon;

            // 3) Eğer yeni bir resim yüklenmişse, yeni yolunu ata; yoksa hiçbir değişiklik yapma
            if (Image is not null)
            {
                dbTreatment.Image = await FileHelper.FileLoaderAsync(Image);
            }

            // 4) Kaydet
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Treatments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatment = await _context.Treatments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (treatment == null)
            {
                return NotFound();
            }

            return View(treatment);
        }

        // POST: Admin/Treatments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var treatment = await _context.Treatments.FindAsync(id);
            if (treatment != null)
            {
                _context.Treatments.Remove(treatment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreatmentExists(int id)
        {
            return _context.Treatments.Any(e => e.Id == id);
        }
    }
}
