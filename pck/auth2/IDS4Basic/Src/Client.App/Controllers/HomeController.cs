using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Client.App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Client.App.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}
		
		[Authorize]
		public IActionResult PrivateData()
		{
			return View();
		}



		// put it in the other file [Route("/callapi")]
		//[Route("/callapi")]
		public async Task<IActionResult> CallApi()
		{
			var apiUrl = "https://localhost:44369/api/weatherforecast/call-api";

			var accessToken = await HttpContext.GetTokenAsync("access_token");

			var client = new HttpClient();

			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

			//6001
			//			var content = await client.GetStringAsync("https://localhost:4369/identity");

			HttpResponseMessage response = await client.GetAsync(apiUrl);

			// do i need a try block 
			//added
			if (response.IsSuccessStatusCode)
			{
				//var json
				var data = await response.Content.ReadAsStringAsync();
				ViewData["data"] = data;
				// EntityType entity = Newtonsoft.Json.JsonConvert.DeserializeObject<EntityType>(data);
			}
			else
			{
				ViewData["data"] = "Error: " + response.StatusCode;
			}

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
