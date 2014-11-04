using ConsoleApplication1.Domain;
using ConsoleApplication1.Mapping;
using System.Data.Entity;

namespace ConsoleApplication1.DataContext
{
    public class AppDataContext : DbContext
    {
        public AppDataContext()
            : base("AppConnStr")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new BookMap());
            modelBuilder.Configurations.Add(new AuthorMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
