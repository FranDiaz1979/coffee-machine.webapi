namespace WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models;
    using Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class DrinkController : ControllerBase
    {
        private readonly ILogger<DrinkController> log;

        public DrinkController(ILogger<DrinkController> logger)
        {
            this.log = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Drink>> Get()
        {
            var drinkService = new DrinkService();
            var result = drinkService.ReadAll();
            return this.Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post(string drinkType, float money, int sugars, int extraHot)
        {
            var drinkService = new DrinkService();
            var drink = new Drink
            {
                DrinkType = drinkType,
                Money = money,
                Sugars = sugars,
                ExtraHot = extraHot,
            };
            var result = await drinkService.PedirAsync(drink);
            this.log.LogDebug(System.Reflection.MethodBase.GetCurrentMethod().Name + " executed");
            return this.Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Drink>> GetById(int id)
        {
            var drinkService = new DrinkService();
            var result = await drinkService.GetByIdAsync(id);

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }
    }
}