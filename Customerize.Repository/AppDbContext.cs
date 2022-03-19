using Customerize.Core.Entities;
using Customerize.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Customerize.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<RegionShipper> RegionShippers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//All configurations in the working assembly

            base.OnModelCreating(modelBuilder);
        }

        public void Commit1()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.DeletedDate = DateTime.Now;
                        break;
                }
            }
            base.SaveChanges();
        }

        public Task CommitAsync1()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        //ToDo:  Added user property
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        //ToDo: Updated  user property
                        entry.Entity.UpdatedDate = DateTime.Now;
                        break;

                    case EntityState.Deleted:
                        //ToDo: Deleted user property
                        entry.Entity.DeletedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync();
        }
    }
}
