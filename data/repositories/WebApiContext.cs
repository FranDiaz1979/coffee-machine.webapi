namespace Repositories
{
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public class WebApiContext : DbContext
    {
        private readonly string connectionString = "SERVER=localhost; DATABASE=aboTest ; UID=root; PASSWORD=QsB3N09NCfeaJ48mn6Su;";
        public DbSet<Order> Orders { get; set; }

        ////public override void Dispose()
        ////{
        ////    ////base.Dispose();
        ////}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseMySQL(this.connectionString);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        throw new MyDataBaseException("Cannot connect to server.  Contact administrator", ex);
                    case 1045:
                        throw new MyDataBaseException("Invalid username/password, please try again", ex);
                    default:
                        throw new MyDataBaseException(ex.Number + ". " + ex.Message, ex);
                }
            }
        }
    }
}
