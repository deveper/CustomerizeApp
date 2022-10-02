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
    internal class ProductDocumentConfiguration : IEntityTypeConfiguration<ProductDocument>
    {
        public void Configure(EntityTypeBuilder<ProductDocument> builder)
        {
            builder.HasOne(ad => ad.Product)
                 .WithMany(ad => ad.ProductDocuments)
                 .HasForeignKey(ad => ad.ProductId)
                 .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
