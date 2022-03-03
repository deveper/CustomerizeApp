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
    internal class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.HasKey(pt => pt.Id);
            builder.Property(pt => pt.Id).UseIdentityColumn();
            builder.Property(pt => pt.Name).IsRequired().HasMaxLength(100);

            builder.HasMany(pt => pt.Products).WithOne(pt => pt.productType);
        }
    }
}
