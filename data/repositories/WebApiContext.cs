namespace Repositories
{
    using System;
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public class WebApiContext : DbContext
    {
        private readonly string connectionString = "SERVER=localhost; DATABASE=aboTest ; UID=root; PASSWORD=QsB3N09NCfeaJ48mn6Su;";
        public DbSet<Order> Orders { get; set; }

        public override void Dispose()
        {
            ////base.Dispose();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseMySQL(connectionString);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        throw new Exception("Cannot connect to server.  Contact administrator");
                    case 1045:
                        throw new Exception("Invalid username/password, please try again");
                    default:
                        throw new Exception(ex.Number + ". " + ex.Message);
                }
            }
        }
    }
}
