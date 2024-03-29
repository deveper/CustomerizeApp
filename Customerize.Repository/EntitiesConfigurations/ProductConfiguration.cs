﻿using Customerize.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customerize.Repository.EntitiesConfigurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(150);
            builder.Property(p => p.Stock).IsRequired();
            builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");//****************,**

            //Category
            builder.HasOne(c => c.Category)//one Category
                   .WithMany(p => p.Products)//in Products
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.SetNull);
            //ProductType
            builder.HasOne(p => p.ProductType)//one ProductType
                   .WithMany(p => p.Products)//in products
                   .HasForeignKey(p => p.ProductTypeId)
                   .OnDelete(DeleteBehavior.SetNull);//Products for FK ProductTypeId
        }
    }
}
