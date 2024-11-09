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
    internal class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.Property(S => S.Id).UseIdentityColumn(10, 10);
            builder.Property(S => S.Code).HasColumnType("varchar(50)").IsRequired(true);
            builder.Property(S => S.Name).HasColumnType("varchar(50)").IsRequired(true);
            builder.HasMany(S => S.StoreItems)
                .WithOne(IS=>IS.Store);

        }
    }
}
