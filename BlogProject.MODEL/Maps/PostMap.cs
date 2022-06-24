﻿using BlogProject.CORE.Map;
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
    public class PostMap:CoreMap<Post>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.Property(z => z.Title).HasMaxLength(100).IsRequired(true);
            builder.Property(z => z.PostDetail).HasMaxLength(2000).IsRequired(true);
            builder.Property(z => z.Tags).HasMaxLength(100).IsRequired(true);
            builder.Property(z => z.ImageURL).HasMaxLength(255).IsRequired(true);
            //builder.Property(z => z.ViewCount).IsRequired(true);


            base.Configure(builder);
        }
    }
}
