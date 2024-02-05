using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NSubstitute;
using RichardSzalay.MockHttp;
using System.ComponentModel;
using System;
using System.Diagnostics;
using System.Numerics;
using Viator_practice.Services;
using Xunit.Abstractions;

namespace Tests
{
    public class ActivityServiceTest
    {


        [Fact]
        public async void getActivities()
        {
            String stringDeProductos = "{\r\n    \"products\": [\r\n        {\r\n            \"productCode\": \"203530P1\",\r\n            \"title\": \"Private City Tour of the City of Buenos Aires with a local guide\",\r\n            \"description\": \"Our VIP Private City Tour will allow you to discover a large number of attractions and curiosities of the city of Buenos Aires in a relaxed and exclusive atmosphere with a bilingual guide. The tour is ideal to do during the first days of your stay in the city. It is also perfectly suited to those passengers on cruises, or in transit, who have few hours to walk.\\nIf you already know the city, since this tour is customizable, we offer you the possibility of personalizing the tour and visiting those places that you have not yet visited.'\\n\",\r\n            \"images\": [\r\n                {\r\n                    \"imageSource\": \"SUPPLIER_PROVIDED\",\r\n                    \"caption\": \"\",\r\n                    \"isCover\": true,\r\n                    \"variants\": [\r\n                        {\r\n                            \"height\": 50,\r\n                            \"width\": 50,\r\n                            \"url\": \"https://hare-media-cdn.tripadvisor.com/media/attractions-splice-spp-50x50/09/54/11/e0.jpg\"\r\n                        },\r\n                        {\r\n                            \"height\": 100,\r\n                            \"width\": 100,\r\n                            \"url\": \"https://hare-media-cdn.tripadvisor.com/media/attractions-splice-spp-100x100/09/54/11/e0.jpg\"\r\n                        },\r\n                        {\r\n                            \"height\": 200,\r\n                            \"width\": 200,\r\n                            \"url\": \"https://hare-media-cdn.tripadvisor.com/media/attractions-splice-spp-200x200/09/54/11/e0.jpg\"\r\n                        },\r\n                        {\r\n                            \"height\": 400,\r\n                            \"width\": 400,\r\n                            \"url\": \"https://hare-media-cdn.tripadvisor.com/media/attractions-splice-spp-400x400/09/54/11/e0.jpg\"\r\n                        },\r\n                        {\r\n                            \"height\": 40,\r\n                            \"width\": 60,\r\n                            \"url\": \"https://hare-media-cdn.tripadvisor.com/media/attractions-splice-spp-60x40/09/54/11/e0.jpg\"\r\n                        },\r\n                        {\r\n                            \"height\": 80,\r\n                            \"width\": 120,\r\n                            \"url\": \"https://hare-media-cdn.tripadvisor.com/media/attractions-splice-spp-120x80/09/54/11/e0.jpg\"\r\n                        },\r\n                        {\r\n                            \"height\": 120,\r\n                            \"width\": 180,\r\n                            \"url\": \"https://hare-media-cdn.tripadvisor.com/media/attractions-splice-spp-180x120/09/54/11/e0.jpg\"\r\n                        },\r\n                        {\r\n                            \"height\": 160,\r\n                            \"width\": 240,\r\n                            \"url\": \"https://hare-media-cdn.tripadvisor.com/media/attractions-splice-spp-240x160/09/54/11/e0.jpg\"\r\n                        },\r\n                        {\r\n                            \"height\": 240,\r\n                            \"width\": 360,\r\n                            \"url\": \"https://hare-media-cdn.tripadvisor.com/media/attractions-splice-spp-360x240/09/54/11/e0.jpg\"\r\n                        },\r\n                        {\r\n                            \"height\": 320,\r\n                            \"width\": 480,\r\n                            \"url\": \"https://hare-media-cdn.tripadvisor.com/media/attractions-splice-spp-480x320/09/54/11/e0.jpg\"\r\n                        },\r\n                        {\r\n                            \"height\": 360,\r\n                            \"width\": 540,\r\n                            \"url\": \"https://hare-media-cdn.tripadvisor.com/media/attractions-splice-spp-540x360/09/54/11/e0.jpg\"\r\n                        },\r\n                        {\r\n                            \"height\": 446,\r\n                            \"width\": 674,\r\n                            \"url\": \"https://hare-media-cdn.tripadvisor.com/media/attractions-splice-spp-674x446/09/54/11/e0.jpg\"\r\n                        },\r\n                        {\r\n                            \"height\": 480,\r\n                            \"width\": 720,\r\n                            \"url\": \"https://hare-media-cdn.tripadvisor.com/media/attractions-splice-spp-720x480/09/54/11/e0.jpg\"\r\n                        },\r\n                        {\r\n                            \"height\": 118,\r\n                            \"width\": 210,\r\n                            \"url\": \"https://hare-media-cdn.tripadvisor.com/media/attractions-splice-spp-210x118/09/54/11/e0.jpg\"\r\n                        },\r\n                        {\r\n                            \"height\": 75,\r\n                            \"width\": 75,\r\n                            \"url\": \"https://hare-media-cdn.tripadvisor.com/media/attractions-splice-spp-75x75/09/54/11/e0.jpg\"\r\n                        },\r\n                        {\r\n                            \"height\": 109,\r\n                            \"width\": 154,\r\n                            \"url\": \"https://hare-media-cdn.tripadvisor.com/media/attractions-splice-spp-154x109/09/54/11/e0.jpg\"\r\n                        }\r\n                    ]\r\n                }\r\n            ],\r\n            \"reviews\": {\r\n                \"sources\": [\r\n                    {\r\n                        \"provider\": \"VIATOR\",\r\n                        \"totalCount\": 417,\r\n                        \"averageRating\": 5.0\r\n                    },\r\n                    {\r\n                        \"provider\": \"TRIPADVISOR\",\r\n                        \"totalCount\": 833,\r\n                        \"averageRating\": 5.0\r\n                    }\r\n                ],\r\n                \"totalReviews\": 1250,\r\n                \"combinedAverageRating\": 4.8936\r\n            },\r\n            \"duration\": {\r\n                \"fixedDurationInMinutes\": 240\r\n            },\r\n            \"confirmationType\": \"INSTANT\",\r\n            \"itineraryType\": \"STANDARD\",\r\n            \"pricing\": {\r\n                \"summary\": {\r\n                    \"fromPrice\": 149.00,\r\n                    \"fromPriceBeforeDiscount\": 149.00\r\n                },\r\n                \"currency\": \"USD\"\r\n            },\r\n            \"productUrl\": \"https://shop.live.rc.viator.com/tours/Buenos-Aires/Private-car-city-tour-up-to-4-people/d901-203530P1?mcid=42383&pid=P00128232&medium=api&api_version=2.0\",\r\n            \"destinations\": [\r\n                {\r\n                    \"ref\": \"901\",\r\n                    \"primary\": true\r\n                }\r\n            ],\r\n            \"tags\": [\r\n                21946,\r\n                11930,\r\n                12075,\r\n                21733,\r\n                21768,\r\n                12029,\r\n                21736,\r\n                22170,\r\n                11938,\r\n                12056,\r\n                11929,\r\n                12028,\r\n                11941,\r\n                21972\r\n            ],\r\n            \"flags\": [\r\n                \"FREE_CANCELLATION\",\r\n                \"PRIVATE_TOUR\"\r\n            ],\r\n            \"translationInfo\": {\r\n                \"containsMachineTranslatedText\": true,\r\n                \"translationSource\": \"MACHINE\",\r\n                \"translationAttribution\": \"GOOGLE\"\r\n            }\r\n        }]}";


            //Creación de lista de productos
            List<Product> productosEsperados = new List<Product>
            {
                new Product { productCode = "203530P1", title = "Private City Tour of the City of Buenos Aires with a local guide", description = "Our VIP Private City Tour will allow you to discover a large number of attractions and curiosities of the city of Buenos Aires in a relaxed and exclusive atmosphere with a bilingual guide. The tour is ideal to do during the first days of your stay in the city. It is also perfectly suited to those passengers on cruises, or in transit, who have few hours to walk.\nIf you already know the city, since this tour is customizable, we offer you the possibility of personalizing the tour and visiting those places that you have not yet visited.'\n", image = "https://hare-media-cdn.tripadvisor.com/media/attractions-splice-spp-720x480/09/54/11/e0.jpg", pricing =  (float)149.00, productUrl = "https://shop.live.rc.viator.com/tours/Buenos-Aires/Private-car-city-tour-up-to-4-people/d901-203530P1?mcid=42383&pid=P00128232&medium=api&api_version=2.0", destinationId = 901, rating = 0 }
            };


            // 1) Inicializacion de Mocks
            var httpMessageHandlerMock = new MockHttpMessageHandler();
            // Setup a respond for the user api (including a wildcard in the URL)
            httpMessageHandlerMock.When("https://api.sandbox.viator.com/partner/products/search").Respond("application/json", stringDeProductos);
            
            var httpClientWithMock = httpMessageHandlerMock.ToHttpClient();

            // Mock de HttpClientFactory
            var httpClientFactoryMock = Substitute.For<IHttpClientFactory>();
            httpClientFactoryMock.CreateClient(Arg.Any<string>()).Returns(httpClientWithMock);


            // 3) Setup de servicio
            ActivityService activityService = new ActivityService(httpClientFactoryMock);

            // 4) Accion
            int idArgentina = 78;
            List<Product> result = await activityService.getActivities(idArgentina);


            if (productosEsperados != result)
            {
                Debug.WriteLine("Productos Esperados:");
                Debug.WriteLine(JsonConvert.SerializeObject(productosEsperados, Formatting.Indented));

                Debug.WriteLine("Resultado:");
                Debug.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));

            }

            // 5) Verificacion
            productosEsperados.Should().BeEquivalentTo(result);
        }
    }
}
