using System;
using System.Collections.Generic;
using System.Linq;
using models;
using repositories;

namespace services
{
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
            //IEnumerable<Drink> result;

            var orderRepository = new OrderRepository();
            var orders = orderRepository.ReadAll();

            foreach (var order in orders)
            {
                var drink = new Drink
                {
                    DrinkType = drinkPrices.Where(x=>x.Name==order.DrinkType).Single().Name,                    
                    Money = drinkPrices.Where(x => x.Name == order.DrinkType).Single().Price,
                    Sugars = order.Sugars,
                    ExtraHot = order.ExtraHot,
                };
                yield return drink;
            }
        }
    }
}
