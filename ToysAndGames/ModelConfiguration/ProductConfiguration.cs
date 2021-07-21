using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysAndGames.Data;

namespace ToysAndGames.ModelConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.Property(t => t.Name).IsRequired().HasMaxLength(50);
            builder.Property(t => t.Description).IsRequired().HasMaxLength(100);
            //builder.Property(t => t.AgeRestriction)
            builder.Property(t => t.Company).IsRequired().HasMaxLength(50);
            builder.Property(t => t.Price).IsRequired();
            builder.HasData(Get());

            //builder
            //    .HasOne(t => t.ProductType)
            //    .WithMany(t => t.Products)
            //    .HasForeignKey(t => t.ProductTypeId);

        }

        private IEnumerable<Product> Get()
        {
            return new List<Product>()
            {
                new Product{Id = 1, Name = "Woody", Description = "Amazing friend", AgeRestriction = 4, Company = "Mattel", Price = 255, ProductTypeId = 1},
                new Product{Id = 2, Name = "Venom", Description = "Added to your collection", AgeRestriction = 10, Company = "Mattel", Price = 314, ProductTypeId = 1},
                new Product{Id = 3, Name = "Blue", Description = "The best dinosaurus", AgeRestriction = 5, Company = "Mattel", Price = 180, ProductTypeId = 1},
                new Product{Id = 4, Name = "IronMan", Description = "I am IronMan", AgeRestriction = 12, Company = "Mattel", Price = 333, ProductTypeId = 1},
                new Product{Id = 5, Name = "Jam", Description = "Take away from my way", AgeRestriction = 3, Company = "Mattel", Price = 120, ProductTypeId = 1},
                new Product{Id = 6, Name = "SpiderMan", Description = "Your friendly neighbor", AgeRestriction = 8, Company = "Mattel", Price = 452, ProductTypeId = 1},
            };
        }
    }
}
