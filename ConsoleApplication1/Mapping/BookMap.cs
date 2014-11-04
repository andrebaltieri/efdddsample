using ConsoleApplication1.Domain;
using System.Data.Entity.ModelConfiguration;

namespace ConsoleApplication1.Mapping
{
    public class BookMap : EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            ToTable("Book");

            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(60);

            HasMany(x => x.Authors).WithMany(x => x.Books).Map(x => x.ToTable("AuthorBook"));
        }
    }
}
