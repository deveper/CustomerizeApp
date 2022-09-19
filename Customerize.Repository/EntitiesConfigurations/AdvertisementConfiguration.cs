using Customerize.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerize.Repository.EntitiesConfigurations
{
    internal class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
    {


        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            //appuser
            builder.HasOne(ad => ad.AppUser)
                .WithMany(ad => ad.Advertisements)
                .HasForeignKey(ad => ad.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
