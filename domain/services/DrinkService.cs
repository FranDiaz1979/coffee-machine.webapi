namespace services
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using models;
    using repositories;

    //TODO: Quitar magic strings
    public class DrinkService
    {
        List<DrinkPrice> drinkPrices = new List<DrinkPrice>
        {
            new DrinkPrice{ Price = 0.4F, Name = "Tea" },
            new DrinkPrice{ Price = 0.5F, Name = "Coffee" },
            new DrinkPrice{ Price = 0.6F, Name = "Chocolate" },
        };

        public IEnumerable<Drink> ReadAll()
        {
            var orderRepository = new OrderRepository();
            var orders = orderRepository.ReadAll();

            foreach (var order in orders)
            {
                var drink = new Drink
                {
                    DrinkType = drinkPrices.Where(x => x.Name == order.DrinkType).Single().Name,
                    Money = drinkPrices.Where(x => x.Name == order.DrinkType).Single().Price,
                    Sugars = order.Sugars,
                    ExtraHot = order.ExtraHot,
                };
                yield return drink;
            }
        }

        public string Pedir(string drinkType, float money, int sugars, int extraHot)
        {
            if (!ComprobarQueExisteBebida(drinkType))
            {
                return "The drink type should be tea, coffee or chocolate.";
            }

            if (!ComprobarQueHayaSuficienteDinero(drinkType, money))
            {
                return String.Format("The {0} costs {1}.",
                    drinkPrices.Where(x => x.Name.ToLower() == drinkType.ToLower()).Single().Name,
                    drinkPrices.Where(x => x.Name.ToLower() == drinkType.ToLower()).Single().Price.ToString("N", new CultureInfo("en-US")));
            }

            if (!ComprobarAzucarillos(sugars))
            {
                return "The number of sugars should be between 0 and 2.";
            }

            //TODO: OrderRepository.Add(...);

            return GenerarFraseSalida(drinkType, extraHot, sugars);
        }

        private static string GenerarFraseSalida(string drinkType, int extraHot, int sugars)
        {
            String result;
            result = String.Format("You have ordered a {0}", drinkType.ToLower());

            if (extraHot > 0)
            {
                result += " extra hot";
            }

            if (sugars > 0)
            {
                result += String.Format(" with {0} sugars(stick included).", sugars);
            }

            return result;
        }

        private static bool ComprobarAzucarillos(int sugars)
        {
            return sugars >= 0 && sugars <= 2;
        }

        private bool ComprobarQueHayaSuficienteDinero(string drinkType, float money)
        {
            return money >= drinkPrices.Where(x => x.Name.ToLower() == drinkType.ToLower()).Single().Price;
        }

        private bool ComprobarQueExisteBebida(string drinkType)
        {
            if (drinkType == null) return false;
            return drinkPrices.Where(x => x.Name.ToLower() == drinkType.ToLower()).Any();
        }
    }
}
