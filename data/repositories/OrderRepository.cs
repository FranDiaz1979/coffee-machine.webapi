namespace Repositories
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

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

        public async Task<IEnumerable<Order>> ReadAllAsync()
        {
            using var dbContext = new WebApiContext();
            return dbContext.Orders;
        }

        public async Task AddAsync(Order order)
        {
            using var dbContext = new WebApiContext();
            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            using var dbContext = new WebApiContext();
            return await dbContext.Orders.FindAsync(id);
        }
    }
}