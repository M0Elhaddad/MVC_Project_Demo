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
    internal class ItemStoreConfiguration : IEntityTypeConfiguration<ItemStore>
    {
        public void Configure(EntityTypeBuilder<ItemStore> builder)
        {
            builder.Property(IS => IS.Id).UseIdentityColumn(1, 1);
            builder.HasKey(IS => new {IS.ItemId,IS.StoreId,IS.Id});
        }
    }
}
