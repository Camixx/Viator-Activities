using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System.Globalization;
using Viator_practice.Controllers;
using Viator_practice.Models;

namespace Viator_practice.Services
{
    public class DestinationService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private HttpClient _httpClient;
        private readonly IMemoryCache _cache;
        private readonly ILogger<HomeController> _logger;

        public DestinationService(IHttpClientFactory httpClientFactory, IMemoryCache cache)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://api.sandbox.viator.com/partner/");
            _httpClient.DefaultRequestHeaders.Add("exp-api-key", "06b8ac04-81bd-4601-a3af-d7fc86bea76e");
            _httpClient.DefaultRequestHeaders.Add("Accept-Language", "en-US");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json;version=2.0");

            _cache = cache;
        }

        //Obtiene los datos si la cache los tiene, caso contrario se buscan y guardan en la cache para despues devolverse
        public async Task<List<Destination>> GetDestinationsFromCache()
        {
            string key = "destinations";

            if (_cache.TryGetValue(key, out List<Destination> data))
            {
                return data;
            }

            data = await getDestinationsFromApi();

            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(60));

            _cache.Set(key, data, cacheOptions);

            return data;
        }

        // obtiene los datos de la api para despues devolverlos
        async Task<List<Destination>> getDestinationsFromApi()
        {
            var listDestinations = new List<Destination>();
            HttpResponseMessage response = await _httpClient.GetAsync("v1/taxonomy/destinations");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(responseBody);

                foreach (JObject i in json["data"])
                {
                    Destination destination = new Destination((int)i["sortOrder"], (bool)i["selectable"], (string)i["destinationUrlName"], (string)i["defaultCurrencyCode"],
                        (string)i["lookupId"], (int)i["parentId"], (string)i["timeZone"], (string)i["iataCode"], (string)i["destinationName"], (int)i["destinationId"], (string)i["destinationType"],
                        (float)i["latitude"], (float)i["longitude"]);

                    listDestinations.Add(destination);
                }
            }
            else
            {
                Console.WriteLine($"Error en la solicitud. Código: {response.StatusCode}");
            }

            return listDestinations;
        }

        public async Task<List<Tuple<int, String>>> obtenerDestinos(String destinoBuscado)
        {
            List<Tuple<int, String>> tuplesArray = new List<Tuple<int, String>>();
            List<Destination> listaDestinos = await GetDestinationsFromCache();
            CultureInfo ci = new CultureInfo("en-US");

            foreach (Destination d in listaDestinos)
            {
                var destinationName = d.destinationName;

                if (destinoBuscado != null)
                {
                    if (destinationName.StartsWith(destinoBuscado, true, ci))
                    {
                        tuplesArray.Add(new Tuple<int, String>(d.destinationId,destinationName));
                    }
                }
            }

            return tuplesArray;
        }
    }
}
