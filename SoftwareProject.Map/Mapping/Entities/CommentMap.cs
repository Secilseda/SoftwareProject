using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftwareProject.Entities.Entity;
using SoftwareProject.Kernel.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareProject.Map.Mapping.Entities
{
    public class CommentMap:KernelMap<Comment>//Commenti Tip olarak veriyoruz.
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {//bire'çok ilişkileri bunlaral tanımlıyoruz.


            builder.Property(x => x.Content).HasMaxLength(150).IsRequired();

            builder.HasOne(x => x.User)//bir comentin olması için ilk etapta bir user olması gerekiyor.
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Post)//Ve postu olmak zorunda
                .WithMany(x => x.Comments)//bir postun bir çok commenti olabilir.
                .HasForeignKey(x => x.PostId);

            base.Configure(builder);//Configure et demek.Configure ettiğimiz yere gönderiyor.
        }
    }
}
