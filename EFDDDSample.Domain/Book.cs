using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EFDDDSample.Domain
{
    public class Book
    {
        private IList<Author> _authors { get; set; }

        protected Book() { this._authors = new List<Author>(); }

        public Book(string name)
        {
            this.Name = name;
            this._authors = new List<Author>();
        }

        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public ICollection<Author> Authors
        {
            get { return _authors; }
            protected set { _authors = new List<Author>(value); }
        }

        public void AddAuthor(Author author)
        {
            this._authors.Add(author);
        }
    }
}
