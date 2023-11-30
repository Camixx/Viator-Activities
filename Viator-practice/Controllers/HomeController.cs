using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http;
using Viator_practice.Models;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Net;
using System;


namespace Viator_practice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://api.sandbox.viator.com/partner/");
            _httpClient.DefaultRequestHeaders.Add("exp-api-key", "06b8ac04-81bd-4601-a3af-d7fc86bea76e"); 
            _httpClient.DefaultRequestHeaders.Add("Accept-Language", "en-US");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json;version=2.0");

            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {

            var response = await _httpClient.GetAsync("v1/taxonomy/destinations");
            var contentString = await response.Content.ReadAsStringAsync();
 
            ViewData["Destinations"] = contentString;

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
