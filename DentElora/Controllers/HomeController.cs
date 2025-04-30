using System.Diagnostics;
using DentElora.Data;
using DentElora.Models;
using Microsoft.AspNetCore.Mvc;

namespace DentElora.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;

        public HomeController(ILogger<HomeController> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new HomePageViewModel();
            model.Sliders = _context.Sliders.ToList();
            model.HomeInfos = _context.HomeInfos.ToList();
            model.Treatments = _context.Treatments.ToList();
            model.Doctors = _context.Doctors.ToList();
            model.Services = _context.Services.ToList();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
