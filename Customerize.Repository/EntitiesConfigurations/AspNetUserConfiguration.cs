using Customerize.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customerize.Repository.EntitiesConfigurations
{
    internal class AspNetUserConfiguration : IEntityTypeConfiguration<AspNetUser>
    {
        public void Configure(EntityTypeBuilder<AspNetUser> builder)
        {
            builder.HasOne(o => o.Company)
                    .WithMany(o => o.AppUsers)
                    .HasForeignKey(o => o.CompanyId)
                    .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
