using ConsoleApplication1.Domain;
using System.Data.Entity.ModelConfiguration;

namespace ConsoleApplication1.Mapping
{
    public class AuthorMap : EntityTypeConfiguration<Author>
    {
        public AuthorMap()
        {
            ToTable("Author");

            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(60);
        }
    }
}
