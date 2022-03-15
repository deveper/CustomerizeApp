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
    internal class RegionShipperConfiguration : IEntityTypeConfiguration<RegionShipper>
    {
        public void Configure(EntityTypeBuilder<RegionShipper> builder)
        {
            builder.HasKey(rs => new { rs.RegionId, rs.ShipperId });
            builder.Property(rs => rs.Id).UseIdentityColumn();

            builder.HasOne(rs => rs.Region)
                .WithMany(r => r.RegionShippers)
                .HasForeignKey(rs => rs.RegionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(rs => rs.Shipper)
                .WithMany(s => s.RegionShippers)
                .HasForeignKey(rs => rs.ShipperId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
