using EFDDDSample.Domain;
using System.Data.Entity.ModelConfiguration;

namespace EFDDDSample.Mapping
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
