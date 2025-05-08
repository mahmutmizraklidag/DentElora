using DentElora.Data;
using Microsoft.AspNetCore.Mvc;

namespace DentElora.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly DatabaseContext _context;

        public AboutUsController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model=_context.AboutUs.FirstOrDefault();
            return View(model);
        }
    }
}
