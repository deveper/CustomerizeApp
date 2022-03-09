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
    internal class OrderLineConfiguration : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).UseIdentityColumn();


            //Order
            builder.HasOne(o => o.Order)
                .WithMany(o => o.OrderLines)
                .HasForeignKey(o => o.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            //Product
            builder.HasOne(o => o.Product)
                 .WithMany(o => o.OrderLines)
                 .HasForeignKey(o => o.ProductId)
                 .OnDelete(DeleteBehavior.NoAction);



        }
    }
}
