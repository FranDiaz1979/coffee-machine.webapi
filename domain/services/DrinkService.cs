namespace Services
{
    using Models;
    using Repositories;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    // TODO: Quitar magic strings
    public class DrinkService
    {
        private readonly List<DrinkPrice> drinkPrices = new List<DrinkPrice>
        {
            new DrinkPrice { Price = 0.4F, Name = "Tea" },
            new DrinkPrice { Price = 0.5F, Name = "Coffee" },
            new DrinkPrice { Price = 0.6F, Name = "Chocolate" },
        };

        public IEnumerable<Drink> ReadAll()
        {
            var orderRepository = new OrderRepository();
            var orders = orderRepository.ReadAll();

            foreach (var order in orders)
            {
                var drink = new Drink
                {
                    DrinkType = this.drinkPrices.Single(x => x.Name == order.DrinkType).Name,
                    Money = this.drinkPrices.Single(x => x.Name == order.DrinkType).Price,
                    Sugars = order.Sugars,
                    ExtraHot = order.ExtraHot,
                };
                yield return drink;
            }
        }

        public string Pedir(Drink drink)
        {
            if (!this.ComprobarQueExisteBebida(drink.DrinkType))
            {
                return "The drink type should be tea, coffee or chocolate.";
            }

            if (!this.ComprobarQueHayaSuficienteDinero(drink.DrinkType, drink.Money))
            {
                return string.Format(
                    "The {0} costs {1}.",
                    this.drinkPrices.Single(x => x.Name.ToLower() == drink.DrinkType.ToLower()).Name,
                    this.drinkPrices.Single(x => x.Name.ToLower() == drink.DrinkType.ToLower()).Price.ToString("N", new CultureInfo("en-US")));
            }

            if (!ComprobarAzucarillos(drink.Sugars))
            {
                return "The number of sugars should be between 0 and 2.";
            }

            //// TODO: OrderRepository.Add(...);

            return GenerarFraseSalida(drink);
        }

        private static string GenerarFraseSalida(Drink drink)
        {
            string result;
            result = string.Format("You have ordered a {0}", drink.DrinkType.ToLower());

            if (drink.ExtraHot > 0)
            {
                result += " extra hot";
            }

            if (drink.Sugars > 0)
            {
                result += string.Format(" with {0} sugars(stick included).", drink.Sugars);
            }

            return result;
        }

        private static bool ComprobarAzucarillos(int sugars)
        {
            return sugars >= 0 && sugars <= 2;
        }

        private bool ComprobarQueHayaSuficienteDinero(string drinkType, float money)
        {
            return money >= this.drinkPrices.Single(x => x.Name.ToLower() == drinkType.ToLower()).Price;
        }

        private bool ComprobarQueExisteBebida(string drinkType)
        {
            if (drinkType == null)
            {
                return false;
            }

            return this.drinkPrices.Any(x => x.Name.ToLower() == drinkType.ToLower());
        }
    }
}