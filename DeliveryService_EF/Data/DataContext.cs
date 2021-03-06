using AltexFood_Delivery.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AltexFood_Delivery.DAL.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<DeliveryTariff> DeliveryTariffs { get; set; }
        public DbSet<Deliveryman> Deliverymen { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasMany<Order>();
        }
    }
}
