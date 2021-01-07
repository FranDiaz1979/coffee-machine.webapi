namespace Repositories
{
    using Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class OrderRepository
    {
        public IEnumerable<Order> ReadAll()
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