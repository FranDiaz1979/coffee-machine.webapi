namespace Repositories
{
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public class WebApiContext : DbContext
    {
        private readonly string connectionString = string.Format(
            "SERVER={0}; PORT={1}; DATABASE={2}; UID={3}; PASSWORD={4};",
            MySqlSettings.Default.Server,
            MySqlSettings.Default.Port,
            MySqlSettings.Default.Database,
            MySqlSettings.Default.UId,
            SecretsVaultSettings.Default.Password);

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