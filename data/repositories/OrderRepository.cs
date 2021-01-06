namespace Repositories
{
    using Entities;
    using System.Collections.Generic;

    public class OrderRepository
    {
        //// Simula que hay datos, para probar
        //public IEnumerable<Order> ReadAll()
        //{
        //    var resultado = new List<Order>
        //    {
        //        new Order
        //        {
        //            DrinkType = "Chocolate",
        //            Sugars = 2,
        //            Stick = 1,
        //            ExtraHot = 1,
        //        },
        //        new Order
        //        {
        //            DrinkType = "Coffee",
        //            Sugars = 1,
        //            Stick = 1,
        //            ExtraHot = 0,
        //        },
        //    };
        //    return resultado;
        //}

        public IEnumerable<Order> ReadAll()
        {
            using var dbContext = new WebApiContext();
            return dbContext.Orders;
        }

        public static void Add(Order order)
        {
            using var dbContext = new WebApiContext();
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
        }
    }
}