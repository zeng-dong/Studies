using LazyCache;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cachings.Aspnetcore.DotnetFive.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IAppCache _lazyCache; //= new CachingService();
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IAppCache cache)
        {
            _logger = logger;
            _lazyCache = cache;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await _lazyCache.GetOrAddAsync("Weathers", VeryExpensiveOperation, DateTimeOffset.Now.AddMinutes(30));
        }

        private async Task<IEnumerable<WeatherForecast>> VeryExpensiveOperation()
        {
            Thread.Sleep(5000);

            var rng = new Random();
            var data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray();

            return data;
        }
    }
}
