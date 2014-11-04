using EFDDDSample.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace EFDDDSample.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable("Category");

            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(60);

            HasMany(x => x.Products).WithRequired(x => x.Category).WillCascadeOnDelete();
        }
    }
}
