using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EFDDDSample.Domain
{
    public class Author
    {
        private IList<Book> _books { get; set; }

        protected Author() { this._books = new List<Book>(); }

        public Author(string name)
        {
            this.Name = name;
            this._books = new List<Book>();
        }

        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public ICollection<Book> Books
        {
            get { return _books; }
            protected set { _books = new List<Book>(value); }
        }

        public void AddBook(Book book)
        {
            this._books.Add(book);
        }
    }
}
