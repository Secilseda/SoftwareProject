using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftwareProject.Entities.Entity;
using SoftwareProject.Kernel.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareProject.Map.Mapping.Entities
{
    public class LikeMap:KernelMap<Like>
    {
        public override void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany(x => x.Likes)//tablo "Likes"
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Post)
                .WithMany(x => x.Likes)
                .HasForeignKey(x => x.PostId);
            base.Configure(builder);
        }
    }
}
