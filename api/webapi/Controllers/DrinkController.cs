namespace webapi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using models;
    using services;
    using System.Collections.Generic;

    [ApiController]
    [Route("[controller]")]
    public class DrinkController : ControllerBase
    {
        private readonly ILogger<DrinkController> _logger;

        public DrinkController(ILogger<DrinkController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Drink> Get()
        {
            var drinkService = new DrinkService();
            var result = drinkService.ReadAll();
            return result;
        }

        [HttpPost]
        public string Post(string drinkType, float money, int sugars, int extraHot)
        {
            var drinkService = new DrinkService();
            var result = drinkService.Pedir(drinkType, money, sugars, extraHot);
            return result;
        }
    }
}