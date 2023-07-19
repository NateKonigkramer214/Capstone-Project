using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.MSIdentity.Shared;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;

namespace Capstone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApiKey _apiKey;

        public HomeController(ILogger<HomeController> logger, IOptions<ApiKey> apiKey)
        {
            _logger = logger;
            _apiKey = apiKey.Value;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(
                //    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                //client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                using HttpResponseMessage response = await client.GetAsync("https://imdb-api.com/en/API/ComingSoon/" + _apiKey.apiKey);
                response.Headers.Add("Access-Control-Allow-Origin", "*");

                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    ComingSoonRoot deserialized = JsonConvert.DeserializeObject<ComingSoonRoot>(jsonString);
                    ViewBag.movies = deserialized.items;
                }
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View();
        }

        public IActionResult TailwindTest()
        {
            return View();
        }
        [HttpGet]
		public async Task<ActionResult> MovieBooking()
		{
			using (var client = new HttpClient())
			{
				using HttpResponseMessage response = await client.GetAsync("https://imdb-api.com/en/API/InTheaters/k_n7laq4z4");
				response.Headers.Add("Access-Control-Allow-Origin", "*");

				if (response.IsSuccessStatusCode)
				{
					string jsonString = await response.Content.ReadAsStringAsync();
					Roots deserialized = JsonConvert.DeserializeObject<Roots>(jsonString);
					return View(deserialized);
				}
			}

			return View();
		}


		







		//Browse all movies
		[HttpGet]
        public async Task<ActionResult> Movies()
        {
            using (var client = new HttpClient())
            {
                using HttpResponseMessage response = await client.GetAsync("https://imdb-api.com/en/API/Top250Movies/k_n7laq4z4");
                response.Headers.Add("Access-Control-Allow-Origin", "*");


                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    Top250Data deserialized = JsonConvert.DeserializeObject<Top250Data>(jsonString);
                    ViewBag.movies = deserialized.Items;
                }
            }
            return View();
        }



        [HttpGet]
		public async Task<ActionResult> MovieDetails(string id)
		{
			using (var client = new HttpClient())
			{
				string url = $"https://imdb-api.com/en/API/Title/k_n7laq4z4/{id}/FullCast,Posters,Images,Trailer,Ratings";
				using HttpResponseMessage response = await client.GetAsync(url);
				response.Headers.Add("Access-Control-Allow-Origin", "*");

				if (response.IsSuccessStatusCode)
				{
					string jsonString = await response.Content.ReadAsStringAsync();
					Root deserialized = JsonConvert.DeserializeObject<Root>(jsonString);
					return View(deserialized);
				}
				else
				{
					return View("Error");
				}
			}
		}

		public IActionResult AboutUs()
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