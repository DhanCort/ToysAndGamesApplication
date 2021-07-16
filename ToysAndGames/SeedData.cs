using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysAndGames.Contracts;
using ToysAndGames.Data;
using ToysAndGames.Repository;

namespace ToysAndGames
{
    public static class SeedData
    {
        public static void Seed(
            IProductRepository productrepo
            )
        {
            AddProducts(productrepo);
        }

        private static void AddProducts(IProductRepository productrepo)
        {
            //Verify if there is already data in DB
            var Products = productrepo.FindAll();

            if (Products.Count == 0)
            {
                var ProductList = new List<ProductDataDictionary>
            {
                new ProductDataDictionary{Name = "Woody", Description = "Amazing friend", AgeRestriction = 4, Company = "Mattel", Price = 255},
                new ProductDataDictionary{Name = "Venom", Description = "Added to your collection", AgeRestriction = 10, Company = "Mattel", Price = 314},
                new ProductDataDictionary{Name = "Blue", Description = "The best dinosaurus", AgeRestriction = 5, Company = "Mattel", Price = 180},
                new ProductDataDictionary{Name = "IronMan", Description = "I am IronMan", AgeRestriction = 12, Company = "Mattel", Price = 333},
                new ProductDataDictionary{Name = "Jam", Description = "Take away from my way", AgeRestriction = 3, Company = "Mattel", Price = 120},
                new ProductDataDictionary{Name = "SpiderMan", Description = "Your friendly neighbor", AgeRestriction = 8, Company = "Mattel", Price = 452},
            };

                foreach (var item in ProductList)
                {
                    productrepo.Create(item);
                }
                productrepo.Save();
            }            
        }
    }
}