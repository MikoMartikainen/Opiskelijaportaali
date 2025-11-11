using Microsoft.AspNetCore.Mvc;
using Opiskelijaportaali.Models;
using System.Diagnostics;

namespace Opiskelijaportaali.Controllers
{
    // HomeController hallitsee sovelluksen kotisivua ja yksityisyydensuojakäytäntöä
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // Konstruktorissa injektoidaan lokituspalvelu
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        // Näyttää kotisivun
        public IActionResult Index()
        {
            return View();
        }
        // Näyttää yksityisyydensuojakäytännön sivun
        public IActionResult Privacy()
        {
            return View();
        }
        // Käsittelee virheet ja näyttää virhesivun
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
