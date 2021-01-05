namespace WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models;
    using Services;
    using System.Collections.Generic;

    [ApiController]
    [Route("[controller]")]
    public class DrinkController : ControllerBase
    {
        private readonly ILogger<DrinkController> _logger;

        public DrinkController(ILogger<DrinkController> logger)
        {
            this._logger = logger;
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
            var drink = new Drink
            {
                DrinkType = drinkType,
                Money = money,
                Sugars = sugars,
                ExtraHot = extraHot,
            };
            var result = drinkService.Pedir(drink);
            return result;
        }
    }
}