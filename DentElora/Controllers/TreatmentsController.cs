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
        [Route("tedavi/{slug}")]
        public async Task<IActionResult> Detail(string slug)
        {
            var model = await _context.Treatments
    .FirstOrDefaultAsync(x => x.Slug == slug);

            if (model == null)
                return NotFound();

            return View(model);
        }
    }
}
