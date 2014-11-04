using ConsoleApplication1.Domain;
using System.Data.Entity.ModelConfiguration;

namespace ConsoleApplication1.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Product");
            HasKey(x => x.Id);

            Property(x => x.Name).IsRequired().HasMaxLength(60);
            Property(x => x.CategoryId);
        }
    }
}
