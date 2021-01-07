namespace Repositories
{
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public class WebApiContext : DbContext
    {
        private readonly string connectionString = "SERVER=192.168.1.138; PORT=3305; DATABASE=coffee_machine ; UID=coffee_machine; PASSWORD=coffee_machine;";
        public virtual DbSet<Order> Orders { get; set; }

        public override void Dispose()
        {
            // Evita que haga un dispose antes de tiempo
        }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever();

                entity.Property(e => e.DrinkType)
                    .HasColumnName("drink_type")
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Sugars)
                    .IsRequired();

                entity.Property(e => e.Stick);

                entity.Property(e => e.ExtraHot);
            });
        }
    }
}