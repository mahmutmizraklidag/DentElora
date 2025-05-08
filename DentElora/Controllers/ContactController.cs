using DentElora.Data;
using Microsoft.AspNetCore.Mvc;

namespace DentElora.Controllers
{
    public class ContactController : Controller
    {
        private readonly DatabaseContext _context;

        public ContactController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Contacts.FirstOrDefault();
            return View(model);
        }
    }
}
