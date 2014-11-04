using EFDDDSample.DataContext;
using EFDDDSample.Domain;
using EFDDDSample.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EFDDDSample.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private AppDataContext _context;

        public CategoryRepository(AppDataContext context)
        {
            this._context = context;
        }

        public IList<Category> Get()
        {
            return _context.Categories.ToList();
        }

        public IList<Category> GetWithProducts()
        {
            return _context.Categories.Include(x => x.Products).ToList();
        }

        public Category Get(int id)
        {
            return _context.Categories.Find(id);
        }

        public void SaveOrUpdate(Category entity)
        {
            if (entity.Id == 0)
                _context.Categories.Add(entity);
            else
                _context.Entry<Category>(entity).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Categories.Remove(_context.Categories.Find(id));
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
