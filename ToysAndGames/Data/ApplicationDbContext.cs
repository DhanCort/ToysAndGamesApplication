using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ToysAndGames.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Adding new tables
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductType { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes()
            .Where(x => x.GetInterfaces().Any(type =>
            type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)))
            .ToList();

            //Get all the IEntityTypeConfiguration and execute the HasData()
            foreach (var type in types)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
                var entityType = type.GetGenericInterfaceParameter(typeof(IEntityTypeConfiguration<>));
                modelBuilder.Entity(entityType).HasData();
            }
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
        }
    }

    public static class TypeExtensions
    {
        public static Type GetGenericInterfaceParameter(this Type concreteType, Type interfaceType)
        {
            var _interface = concreteType
            .GetInterfaces()
            .Single(y => y.IsGenericType && y.GetGenericTypeDefinition() == interfaceType);

            return _interface.GetGenericArguments().First();
        }
    }




}

