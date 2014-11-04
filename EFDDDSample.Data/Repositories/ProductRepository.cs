using EFDDDSample.DataContext;
using EFDDDSample.Domain;
using EFDDDSample.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EFDDDSample.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private AppDataContext _context;

        public ProductRepository(AppDataContext context)
        {
            this._context = context;
        }

        public IList<Product> Get()
        {
            return _context.Products.ToList();
        }

        public Product Get(int id)
        {
            return _context.Products.Find(id);
        }

        public void SaveOrUpdate(Product entity)
        {
            if (entity.Id == 0)
                _context.Products.Add(entity);
            else
                _context.Entry<Product>(entity).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Products.Remove(_context.Products.Find(id));
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
