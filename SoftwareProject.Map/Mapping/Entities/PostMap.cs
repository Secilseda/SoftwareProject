using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftwareProject.Entities.Entity;
using SoftwareProject.Kernel.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareProject.Map.Mapping.Entities
{
	public class PostMap:KernelMap<Post>
	{
		//EntityTypeBuilder isterken usinglere metadata istiyor ekliyoruz.=>Microsoft.EntityFrameworkCore.Metadata.Builders;
		public override void Configure(EntityTypeBuilder<Post> builder)//Kerneldaki metot içerisinde,kerneldaki bütün enttylerde ortak olan mappinglerin yapılması.
		{
			builder.Property(x => x.Content).HasMaxLength(140).IsRequired(true);
			builder.Property(x => x.ImagePath).IsRequired(true);

			base.Configure(builder);
		}
	}
}
