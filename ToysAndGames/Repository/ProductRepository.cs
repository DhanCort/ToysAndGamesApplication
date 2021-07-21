using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysAndGames.Contracts;
using ToysAndGames.Data;

namespace ToysAndGames.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(Product entity)
        {
            _db.Products.Add(entity);
            return Save();
        }

        public bool Delete(Product entity)
        {
            _db.Products.Remove(entity);
            return Save();
        }

        public ICollection<Product> FindAll()
        {
            //return _db.Products.ToList();
            return _db.Products.Include(q => q.ProductType).ToList();

        }

        public Product FindById(int id)
        {
            Product product = _db.Products.Include(q => q.ProductType).Where(q => q.Id == id).FirstOrDefault();
            return product;
        }

        public bool Save()
        {
            int value = _db.SaveChanges();
            return value > 0;
        }

        public bool Update(Product entity)
        {
            _db.Products.Update(entity);
            return Save();
        }

    }
}
