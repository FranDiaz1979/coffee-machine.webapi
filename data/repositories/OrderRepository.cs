namespace Repositories
{
    using Entities;
    using System.Collections.Generic;

    public class OrderRepository
    {
        public IEnumerable<Order> ReadAll()
        {
            var resultado = new List<Order>
            {
                new Order
                {
                    DrinkType = "Chocolate",
                    Sugars = 2,
                    Stick = true,
                    ExtraHot = 1,
                },
                new Order
                {
                    DrinkType = "Coffee",
                    Sugars = 1,
                    Stick = true,
                    ExtraHot = 0,
                },
            };
            return resultado;
        }

        // public Order Read(int id)
        // {
        //     var resultado =
        //         new Order
        //         {
        //             DrinkType = "Chocolate",
        //             Sugars=2,
        //             Stick=true,
        //             ExtraHot=1,
        //         };
        //     return resultado;
        // }
    }
}