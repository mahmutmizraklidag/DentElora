using DentElora.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DentElora.Controllers
{
    
    public class FaqsController : Controller
    {
        private readonly DatabaseContext _context;

        public FaqsController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model=_context.FAQs.ToList();
            return View(model);
        }
    }
}
