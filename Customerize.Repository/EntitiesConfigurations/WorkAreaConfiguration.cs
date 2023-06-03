using Customerize.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customerize.Repository.EntitiesConfigurations
{
    internal class WorkAreaConfiguration : IEntityTypeConfiguration<WorkArea>
    {
        public void Configure(EntityTypeBuilder<WorkArea> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).UseIdentityColumn();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(200);
            builder.Property(c => c.isInternal).IsRequired();
        }
    }
}
