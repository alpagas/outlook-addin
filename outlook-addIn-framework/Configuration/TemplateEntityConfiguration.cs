using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace OAFramework.Configuration
{
    public class TemplateEntityConfiguration : EntityTypeConfiguration<EFTemplate>
    {
        public TemplateEntityConfiguration()
        {
            HasOptional(x => x.Parent).WithMany(x => x.Children).Map(m => m.MapKey("Parent_TemplateId"));
            HasMany(x => x.Children).WithOptional(x => x.Parent);
        }
    }
}
