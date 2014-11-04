using System.Collections.Generic;

namespace EFDDDSample.Domain.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        IList<Book> GetWithAuthors();
    }
}
