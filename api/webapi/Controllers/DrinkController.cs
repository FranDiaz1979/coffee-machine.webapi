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
            try
            {
                var drinkService = new DrinkService();
                var result = drinkService.ReadAll();
                return this.Ok(result);
            }
            catch (System.Exception exception)
            {
                log.LogError(exception, string.Format("{0}: Error en {1}", System.DateTime.Now, System.Reflection.MethodBase.GetCurrentMethod().Name));
                return this.StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post(string drinkType, float money, int sugars, int extraHot)
        {
            try
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
                this.log.LogDebug(string.Format("{0}: {1} executed", System.DateTime.Now, System.Reflection.MethodBase.GetCurrentMethod().Name));
                return this.Ok(result);
            }
            catch (Services.BadParametersException exception)
            {
                log.LogInformation(string.Format("{0}: {1}", System.DateTime.Now, exception.Message));
                return this.StatusCode(400, exception.Message);
            }
            catch (System.Exception exception)
            {
                log.LogError(exception, string.Format("{0}: Error en {1}", System.DateTime.Now, System.Reflection.MethodBase.GetCurrentMethod().Name));
                return this.StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Drink>> GetById(int id)
        {
            try
            {
                var drinkService = new DrinkService();
                var result = await drinkService.GetByIdAsync(id);

                if (result == null)
                {
                    return this.NotFound();
                }

                return this.Ok(result);
            }
            catch (System.Exception exception)
            {
                log.LogError(exception, string.Format("{0}: Error en {1}", System.DateTime.Now, System.Reflection.MethodBase.GetCurrentMethod().Name));
                return this.StatusCode(500);
            }
        }
    }
}