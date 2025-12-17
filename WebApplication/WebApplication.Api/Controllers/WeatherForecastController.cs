using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Db;

namespace WebApplication.Api.Controllers
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
        private readonly WeatherDatabaseContext weatherDatabaseContext;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            WeatherDatabaseContext weatherDatabaseContext)
        {
            _logger = logger;
            this.weatherDatabaseContext = weatherDatabaseContext;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return weatherDatabaseContext.WeatherForecasts
                .Select(x => new WeatherForecast()
                {
                    Date = x.Date,
                    Summary = x.Summary,
                    TemperatureC = x.TemperatureC
                }).ToList();
        }
    }
}
