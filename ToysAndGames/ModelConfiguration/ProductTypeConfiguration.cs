using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysAndGames.Data;

namespace ToysAndGames.ModelConfiguration
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.Property(t => t.Name).IsRequired().HasMaxLength(50);
            builder.HasData(Get());

            //builder.HasOne(t => t.Products);
            //builder
            //    .HasMany(t => t.Products)
            //    .WithOne(t => t.ProductType)
            //    .HasForeignKey(t => t.ProductTypeId);
        }

        private IEnumerable<ProductType> Get()
        {
            return new List<ProductType>()
            {
                new ProductType{Id = 1, Name = "Toy" },
                new ProductType{Id = 2, Name = "Game" }
            };
        }
    }
}
