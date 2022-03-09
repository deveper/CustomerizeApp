using Customerize.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerize.Repository.EntitiesConfigurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).UseIdentityColumn();

            //Company
            builder.HasOne(o => o.Company)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);
            //AppUser
            builder.HasOne(o => o.AppUser)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            //Shipper
            builder.HasOne(o => o.Shipper)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.ShipperId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
