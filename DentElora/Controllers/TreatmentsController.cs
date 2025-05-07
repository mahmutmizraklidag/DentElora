using DentElora.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DentElora.Controllers
{
    public class TreatmentsController : Controller
    {
        private readonly DatabaseContext _context;

        public TreatmentsController(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model =await _context.Treatments.ToListAsync();

            return View(model);
        }
        [Route("/Tedavi")]
        public async Task<IActionResult> Detail(int id)
        {
            var model = await _context.Treatments.FindAsync(id);

            return View(model);
        }
    }
}
