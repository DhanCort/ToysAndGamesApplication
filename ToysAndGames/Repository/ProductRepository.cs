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

        public bool Create(ProductDataDictionary entity)
        {
            _db.Products.Add(entity);
            return Save();
        }

        public bool Delete(ProductDataDictionary entity)
        {
            _db.Products.Remove(entity);
            return Save();
        }

        public ICollection<ProductDataDictionary> FindAll()
        {
            return _db.Products.ToList();
        }

        public ProductDataDictionary FindById(int id)
        {
            ProductDataDictionary product = _db.Products.Find(id);
            return product;
        }

        public bool Save()
        {
            int value = _db.SaveChanges();
            return value > 0;
        }

        public bool Update(ProductDataDictionary entity)
        {
            _db.Products.Update(entity);
            return Save();
        }

    }
}
