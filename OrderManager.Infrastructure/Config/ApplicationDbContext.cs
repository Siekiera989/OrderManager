using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OrderManager.DomainModel;

namespace OrderManager.Infrastructure.Config
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Package> Packages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=OrdersDemoDb.db", opt =>
            {
                opt.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(o => o.OwnedOrders)
                .WithOne();

            modelBuilder.Entity<Customer>()
                .HasMany(o => o.OwnedOrders)
                .WithOne();

            modelBuilder.Entity<Customer>()
                .HasOne(cu => cu.Company)
                .WithMany(cu=>cu.ExternalCompanyEmployees)
                .HasForeignKey(fk=>fk.CompanyID);

            modelBuilder.Entity<Order>()
                .HasMany(orderItem => orderItem.Items)
                .WithOne();

            modelBuilder.Entity<Order>()
                .HasOne(c=>c.Customer)
                .WithMany(o=>o.OwnedOrders);

            modelBuilder.Entity<Order>()
                .HasOne(e=>e.Employee)
                .WithMany(e=>e.OwnedOrders);

            modelBuilder.Entity<Package>()
                .HasKey(k => k.PackageID);

            modelBuilder.Entity<OrderItem>()
                .HasKey(k => k.ItemID);

            modelBuilder.Entity<OrderItem>()
                .HasOne(o => o.RelatedOrder)
                .WithMany(i => i.Items);

            modelBuilder.Entity<OrderItem>()
                .HasOne(o => o.Package).WithOne(p=>p.OrderItem)
                .HasForeignKey<Package>(p=>p.OrderItemRef);
        }
    }
}
