using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Client.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	[Authorize]
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<WeatherForecastController> _logger;

		public WeatherForecastController(ILogger<WeatherForecastController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		[Route("getdata")]
		//public IEnumerable<WeatherForecast> Get()
		public ActionResult Get()
		{
			var claims = HttpContext.User.Claims.Select(x => $"{x.Type}:{x.Value}");
			return Ok(new
			{
				Name = "Values API",
				Claims = claims.ToArray()
			});

			//var rng = new Random();
			//return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			//{
			//	Date = DateTime.Now.AddDays(index),
			//	TemperatureC = rng.Next(-20, 55),
			//	Summary = Summaries[rng.Next(Summaries.Length)]
			//})
			//.ToArray();
		}
	}
}
