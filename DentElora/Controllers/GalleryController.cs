using DentElora.Data;
using Microsoft.AspNetCore.Mvc;

namespace DentElora.Controllers
{
    public class GalleryController : Controller
    {
        private readonly DatabaseContext _context;

        public GalleryController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Galleries.ToList();
            return View(model);
        }
    }
}
