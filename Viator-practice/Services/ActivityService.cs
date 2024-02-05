using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Numerics;
using Viator_practice.Controllers;
using Viator_practice.Models;

namespace Viator_practice.Services
{
    public class ActivityService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private HttpClient _httpClient;
        private readonly ILogger<HomeController> _logger;

        public ActivityService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://api.sandbox.viator.com/partner/");
            _httpClient.DefaultRequestHeaders.Add("exp-api-key", "06b8ac04-81bd-4601-a3af-d7fc86bea76e");
            _httpClient.DefaultRequestHeaders.Add("Accept-Language", "en-US");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json;version=2.0");
        }

        public async Task<List<Product>> getActivities(int destinationId)
        {
            var data = new DataModel(destinationId);
            var jsonData = JsonConvert.SerializeObject(data);
            StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("products/search", stringContent);
            List<Product> matches = new List<Product>();

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();

                JObject json = JObject.Parse(responseData);
                List<Product> activities = parsearActivities(json);

                foreach ( Product a in activities ) {
                    matches.Add(a);
                }
            }

            return matches;
        }

        public List<Product> parsearActivities(JObject json)
        {
            List<Product> activities = new List<Product>();
            int i = 0;

            foreach(JObject j in json["products"])
            {
                Product activity = new Product();

                activity.productCode = (string)json["products"][i]["productCode"];
                activity.title = (string)json["products"][i]["title"];
                activity.description = (string)json["products"][i]["description"];
                activity.image = (string)json["products"][i]["images"][0]["variants"][12]["url"];
                activity.pricing = (float)json["products"][i]["pricing"]["summary"]["fromPrice"];
                activity.productUrl = (string)json["products"][i]["productUrl"];
                activity.destinationId = (int)json["products"][i]["destinations"][0]["ref"];

                activities.Add(activity);

                i++;
            }

            return activities;

        }


    }
}
