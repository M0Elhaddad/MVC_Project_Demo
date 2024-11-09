using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Configuration
{
    internal class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(I => I.Name).HasMaxLength(50).IsRequired(true);
            builder.Property(I => I.Description).HasMaxLength(50).IsRequired(true);
            builder.HasMany(I => I.ItemStores)
                .WithOne(IS=>IS.Item);
        }
    }
}
