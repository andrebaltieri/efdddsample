using EFDDDSample.DataContext;
using EFDDDSample.Domain;
using EFDDDSample.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EFDDDSample.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private AppDataContext _context;

        public BookRepository(AppDataContext context)
        {
            this._context = context;
        }

        public IList<Book> Get()
        {
            return _context.Books.ToList();
        }

        public IList<Book> GetWithAuthors()
        {
            return _context.Books.Include(x => x.Authors).ToList();
        }

        public Book Get(int id)
        {
            return _context.Books.Find(id);
        }

        public void SaveOrUpdate(Book entity)
        {
            if (entity.Id == 0)
                _context.Books.Add(entity);
            else
                _context.Entry<Book>(entity).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Books.Remove(_context.Books.Find(id));
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
