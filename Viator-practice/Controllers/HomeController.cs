using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using Viator_practice.Models;
using Viator_practice.Services;
using System.Text.Json;



namespace Viator_practice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DestinationService _destinationService;
        private readonly ActivityService _activityService;

        public HomeController(DestinationService destinationService, ActivityService activityService)
        {
            _destinationService = destinationService;
            _activityService = activityService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            return View();
        }


        [HttpGet("/destinations")]
        public async Task<string> Destinations(string name)
        {
            Task<List<Tuple<int, String>>> resultados = _destinationService.obtenerDestinos(name);
            List <Tuple<int, String>> listaResultados = await resultados;
            var json = JsonConvert.SerializeObject(listaResultados);

            return json;
        }

        [HttpGet("/activities")]
        public async Task<string> Activities(int destinationId)
        {
            var resultados = await _activityService.getActivities(destinationId);

            var json = JsonConvert.SerializeObject(resultados);

            return json;
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
