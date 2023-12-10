using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Viator_practice.Models;
using Viator_practice.Services;

namespace Viator_practice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DestinationService _destinationService;

        public HomeController(DestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public async Task<IActionResult> IndexAsync(string destinoBuscado)
        {
            Task<List<String>> resultados = _destinationService.obtenerDestinos(destinoBuscado);
            List<String> listaResultados = await resultados;

            ViewBag.DestinoBuscado = destinoBuscado;
            ViewBag.Resultados = listaResultados;

            return View();
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
