using BlogProject.CORE.Map;
using BlogProject.MODEL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.MODEL.Maps
{
    public class UserMap:CoreMap<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(z => z.Firstname).HasMaxLength(100).IsRequired(true);
            builder.Property(z => z.LastName).HasMaxLength(100).IsRequired(true);
            builder.Property(z => z.EmailAdress).HasMaxLength(255).IsRequired(true);
            builder.Property(z => z.Title).HasMaxLength(100).IsRequired(true);
            builder.Property(z => z.ImageURL).HasMaxLength(255).IsRequired(false);
            builder.Property(z => z.Password).HasMaxLength(1000).IsRequired(true);
            builder.Property(z => z.LastLogin).IsRequired(false);
            builder.Property(z => z.LastIPAdress).HasMaxLength(20).IsRequired(false);
            base.Configure(builder);
        }
    }
}
