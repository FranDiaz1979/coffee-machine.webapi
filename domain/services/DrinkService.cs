namespace Services
{
    using Models;
    using Repositories;
    using Entities;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    public class DrinkService
    {
        private readonly IEnumerable<DrinkPrice> drinkPrices = new List<DrinkPrice>
        {
            new DrinkPrice { Price = 0.4F, Name = Resources.Tea },
            new DrinkPrice { Price = 0.5F, Name = Resources.Coffee },
            new DrinkPrice { Price = 0.6F, Name = Resources.Chocolate },
        };

        public DrinkService()
        {
            this.DrinkPrices = this.drinkPrices;
        }

        public IEnumerable<DrinkPrice> DrinkPrices { get; }

        public IEnumerable<Drink> ReadAll()
        {
            var orderRepository = new OrderRepository();
            var orders = orderRepository.ReadAllAsync().Result;
            foreach (var order in orders)
            {
                var drink = new Drink
                {
                    DrinkType = this.DrinkPrices.Single(x => x.Name.ToLower() == order.DrinkType.ToLower()).Name,
                    Money = this.DrinkPrices.Single(x => x.Name.ToLower() == order.DrinkType.ToLower()).Price,
                    Sugars = order.Sugars,
                    ExtraHot = order.ExtraHot,
                };
                yield return drink;
            }
        }

        public async Task<string> PedirAsync(Drink drink)
        {
            if (!this.ComprobarQueExisteBebida(drink.DrinkType))
            {
                return Resources.ErrorDrinkNotExist;
            }

            if (!this.ComprobarQueHayaSuficienteDinero(drink.DrinkType, drink.Money))
            {
                return string.Format(
                    Resources.ErrorMoneyNotEnought,
                    this.DrinkPrices.Single(x => x.Name.ToLower() == drink.DrinkType.ToLower()).Name,
                    this.DrinkPrices.Single(x => x.Name.ToLower() == drink.DrinkType.ToLower()).Price.ToString("N", new CultureInfo("en-US")));
            }

            if (!ComprobarAzucarillos(drink.Sugars))
            {
                return Resources.ErrorNumberOfSugars;
            }

            Order order = new Order
            {
                DrinkType = drink.DrinkType,
                Sugars = drink.Sugars,
                Stick = drink.Stick,
                ExtraHot = drink.ExtraHot,
            };

            var orderRepository = new OrderRepository();
            await orderRepository.AddAsync(order);

            return GenerarFraseSalida(drink);
        }

        private static string GenerarFraseSalida(Drink drink)
        {
            string result;
            result = string.Format(Resources.MessageOrdered, drink.DrinkType.ToLower());

            if (drink.ExtraHot > 0)
            {
                result += " " + Resources.MessageExtraHot;
            }

            if (drink.Sugars > 0)
            {
                result += " " + string.Format(Resources.MessageWithSugars, drink.Sugars);
            }

            return result;
        }

        private static bool ComprobarAzucarillos(int sugars)
        {
            return sugars >= 0 && sugars <= 2;
        }

        private bool ComprobarQueHayaSuficienteDinero(string drinkType, float money)
        {
            return money >= this.DrinkPrices.Single(x => x.Name.ToLower() == drinkType.ToLower()).Price;
        }

        private bool ComprobarQueExisteBebida(string drinkType)
        {
            if (drinkType == null)
            {
                return false;
            }

            return this.DrinkPrices.Any(x => x.Name.ToLower() == drinkType.ToLower());
        }

        public async Task<Drink> GetByIdAsync(int id)
        {
            var orderRepository = new OrderRepository();
            var order = await orderRepository.GetByIdAsync(id);

            var drink = new Drink
            {
                DrinkType = order.DrinkType,
                Sugars = order.Sugars,
                ExtraHot = order.ExtraHot,
            };
            return drink;
        }
    }
}