using DentElora.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DentElora.ViewComponents
{
    public class TreatmentsSide : ViewComponent
    {
        private readonly DatabaseContext _context;

        public TreatmentsSide(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var treatments = await _context.Treatments.ToListAsync();
            return View(treatments);
        }
    }
}
