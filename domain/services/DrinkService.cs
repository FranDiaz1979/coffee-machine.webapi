using System;
using System.Collections.Generic;
using models;
using repositories;

namespace services
{
    public class DrinkService
    {
        public IEnumerable<Drink> ReadAll()
        {
            //IEnumerable<Drink> result;

            var orderRepository = new OrderRepository();
            var orders = orderRepository.ReadAll();

            foreach (var order in orders)
            {
                var drink = new Drink
                {
                    DrinkType=order.DrinkType,
                    Sugars=order.Sugars,
                    ExtraHot=order.ExtraHot,
                };
                yield return drink;
            }            
        }
    }
}
