using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using models;
using services;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrinkController : ControllerBase
    {
        // private static readonly string[] Summaries = new[]
        // {
        //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        // };

        private readonly ILogger<DrinkController> _logger;

        public DrinkController(ILogger<DrinkController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Drink> Get()
        {
            // return Enumerable.Range(1, 5).Select(index => new Drink
            // {
            //     Date = DateTime.Now.AddDays(index),
            //     TemperatureC = rng.Next(-20, 55),
            //     Summary = Summaries[rng.Next(Summaries.Length)]
            // })
            // .ToArray();

            var drinkService = new DrinkService();
            var drinks = drinkService.ReadAll();
            return drinks;
            
        }
    }
}
