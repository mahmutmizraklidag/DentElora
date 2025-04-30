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
    public class DoctorsController : Controller
    {
        private readonly DatabaseContext _context;

        public DoctorsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Admin/Doctors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Doctors.ToListAsync());
        }

        // GET: Admin/Doctors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Admin/Doctors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Image,Role")] Doctor doctor, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                if (Image is not null) doctor.Image = await FileHelper.FileLoaderAsync(Image);
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }

        // GET: Admin/Doctors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        // POST: Admin/Doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Image,Role")] Doctor doctor, IFormFile? Image)
        {
            if (id != doctor.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(doctor);

            // 1) Veritabanındaki var olan doktoru alın
            var dbDoctor = await _context.Doctors.FindAsync(id);
            if (dbDoctor == null)
                return NotFound();

            // 2) Sadece güncellenen alanı ata
            dbDoctor.Name = doctor.Name;
            dbDoctor.Role = doctor.Role;
            // 3) Eğer yeni bir resim yüklenmişse, yeni yolunu ata; yoksa hiçbir değişiklik yapma
            if (Image is not null)
            {
                dbDoctor.Image = await FileHelper.FileLoaderAsync(Image);
            }

            // 4) Kaydet
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Doctors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Admin/Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctors.Any(e => e.Id == id);
        }
    }
}
