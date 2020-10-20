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
using System.Security.Claims;

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
			//public IActionResult Get()
			//{
			//return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
			//}

			//return View((User as ClaimsPrincipal).Claims);
			return View(User.Claims);

			// code below to return the actual view
			//return View();
		}


		[Authorize]
		// put it in the other file [Route("/call-api")]
		//[Route("/call-api")]
		public async Task<IActionResult> CallApi()
		{
			var apiUrl = "https://localhost:44369/api/weatherforecast/call-api";

			var accessToken = await HttpContext.GetTokenAsync("access_token");

			var client = new HttpClient();

			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

			HttpResponseMessage response = await client.GetAsync(apiUrl);

			//var data = await response.Content.ReadAsStringAsync();
			//ViewData["data"] = data;

			//return View();


			// do i need a try block 
			//added
			if (response.IsSuccessStatusCode)
			{
				//var json
				var data = await response.Content.ReadAsStringAsync();
				ViewData["data"] = data;
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
