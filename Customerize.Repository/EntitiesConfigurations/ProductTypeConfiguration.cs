using Customerize.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customerize.Repository.EntitiesConfigurations
{
    internal class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.HasKey(pt => pt.Id);
            builder.Property(pt => pt.Id).UseIdentityColumn();
            builder.Property(pt => pt.Name).IsRequired().HasMaxLength(100);

        }
    }
}
