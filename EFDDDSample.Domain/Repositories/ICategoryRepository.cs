using System.Collections.Generic;

namespace EFDDDSample.Domain.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IList<Category> GetWithProducts();
    }
}
