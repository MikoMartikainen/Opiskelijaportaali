using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Opiskelijaportaali.Models;

namespace Opiskelijaportaali.Controllers
{
    // HomeController hallitsee sovelluksen kotisivua ja yksityisyydensuojak�yt�nt��
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // Konstruktorissa injektoidaan lokituspalvelu
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        // N�ytt�� kotisivun
        public IActionResult Index()
        {
            return View();
        }
        // N�ytt�� yksityisyydensuojak�yt�nn�n sivun
        public IActionResult Privacy()
        {
            return View();
        }
        // K�sittelee virheet ja n�ytt�� virhesivun
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
