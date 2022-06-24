using BlogProject.CORE.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.CORE.Map
{
    public abstract class CoreMap<T> : IEntityTypeConfiguration<T> where T : CoreEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(z => z.ID);
            builder.Property(z => z.Status).IsRequired(true);
            builder.Property(z => z.CreatedComputerName).IsRequired(false).HasMaxLength(255);
            builder.Property(z => z.CreatedDate).IsRequired(false);
            builder.Property(z => z.CreatedIP).IsRequired(false).HasMaxLength(15);

            builder.Property(z => z.UpdatedComputerName).IsRequired(false).HasMaxLength(255);
            builder.Property(z => z.UpdatedDate).IsRequired(false);
            builder.Property(z => z.UpdatedIP).IsRequired(false).HasMaxLength(15);
        }
    }
}
