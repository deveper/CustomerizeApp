﻿using Customerize.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Customerize.Repository
{
    public class AppDbContext : IdentityDbContext<AppUser, Role, int>
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
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<ProductDocument> ProductDocuments { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }

        public DbSet<WorkArea> WorkAreas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//All configurations in the working assembly

            base.OnModelCreating(modelBuilder);


        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReferance)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReferance.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                entityReferance.UpdatedDate = DateTime.Now;
                                break;
                            }
                    }
                }

            }


            return base.SaveChangesAsync(cancellationToken);
        }


    }
}
