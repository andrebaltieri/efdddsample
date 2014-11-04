using EFDDDSample.DataContext;
using EFDDDSample.Domain;
using EFDDDSample.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EFDDDSample.Data.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private AppDataContext _context;

        public AuthorRepository(AppDataContext context)
        {
            this._context = context;
        }

        public IList<Author> Get()
        {
            return _context.Authors.ToList();
        }

        public Author Get(int id)
        {
            return _context.Authors.Find(id);
        }

        public void SaveOrUpdate(Author entity)
        {
            if (entity.Id == 0)
                _context.Authors.Add(entity);
            else
                _context.Entry<Author>(entity).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Authors.Remove(_context.Authors.Find(id));
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
