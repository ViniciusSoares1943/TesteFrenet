using FrenetOrder.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace FrenetOrder.Data
{
    public class DbContextClass : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        IConfiguration _configuration;
        public DbContextClass(DbContextOptions<DbContextClass> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
            options.UseSqlServer(_configuration.GetConnectionString("FrenetDbConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("FrenetOrder");

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Cliente)
                .WithMany(p => p.Pedidos)
                .HasForeignKey(o => o.IdCliente)
                .HasConstraintName("FK_Pedidos_Clientes");
        }

    }
}
