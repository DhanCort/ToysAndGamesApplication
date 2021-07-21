using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysAndGames.Contracts;
using ToysAndGames.Data;

namespace ToysAndGames.Repository
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(ProductType entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ProductType entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<ProductType> FindAll()
        {
            return _db.ProductType.ToList();
        }

        public ProductType FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(ProductType entity)
        {
            throw new NotImplementedException();
        }
    }
}
