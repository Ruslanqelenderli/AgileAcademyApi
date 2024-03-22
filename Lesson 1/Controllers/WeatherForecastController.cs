using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IUser user;

        public WeatherForecastController(IUser user)
        {
            this.user = user;
        }

        [HttpGet("Get")]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("Get2")]
        public void Get2()
        {

            WeatherForecastController weatherForecastController = new WeatherForecastController(new User());

        }
    }


    //public class Test
    //{
    //    private readonly ILogger<WeatherForecastController> _logger;

    //    public Test(ILogger<WeatherForecastController> _logger)
    //    {
    //        this._logger = _logger;
    //    }
    //    public  void Main()
    //    {

    //        WeatherForecastController controller = new WeatherForecastController(new Logger<WeatherForecastController>())
    //        _logger.LogInformation("test");
    //    }
    //}
    public class User : IUser
    {
        public string UserName => throw new NotImplementedException();
    }

    public interface IUser
    {
        string UserName { get; }
    }

}
