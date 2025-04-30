using DentElora.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DentElora.ViewComponents
{
    public class Treatment : ViewComponent
    {
        private readonly DatabaseContext _context;

        public Treatment(DatabaseContext context)
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
