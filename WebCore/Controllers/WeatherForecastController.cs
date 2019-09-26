using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBJF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebCore.Controllers
{
    /// <summary>
    /// 系统自带
    /// </summary>
    [ApiController]
    [Route("[controller]")]
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

        /// <summary>
        /// 测试Post
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        //[ApiExplorerSettings(IgnoreApi = true)]隐藏接口
        public IActionResult Post([FromBody] User user)
        {
            return Ok(user);
        }
    }
}
