using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;
using Viator_practice.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



await GuardarDatos();

static async Task GuardarDatos()
{
    string apiUrl = "https://api.sandbox.viator.com/partner/v1/taxonomy/destinations";

    using (HttpClient client = new HttpClient())
    {
        try
        {

            HttpResponseMessage response = await client.GetAsync(apiUrl);


            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(responseBody);

                var listDestinations = new List<Destination>();

                foreach (JObject i in json["data"])
                {


					Destination destination = new Destination((int)i["sortOrder"], (bool)i["selectable"], (string)i["destinationUrlName"], (string)i["defaultCurrencyCode"],
						(string)i["lookupId"], (int)i["parentId"], (string)i["timeZone"], (string)i["iataCode"], (string)i["destinationName"], (int)i["destinationId"], (string)i["destinationType"],
						(float)i["latitude"], (float)i["longitude"]);

                    listDestinations.Add(destination);
                }

                Console.WriteLine("OK");


            }
            else
            {
                Console.WriteLine($"Error en la solicitud. Código: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

app.Run();
