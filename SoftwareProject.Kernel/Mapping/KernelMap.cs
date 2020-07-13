using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftwareProject.Kernel.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SoftwareProject.Kernel.Mapping
{
	public abstract class KernelMap<T> : IEntityTypeConfiguration<T> where T : KernelEntity//T'ler için bir tip geçtik.
	{
		//Builder nesnesi alıp mapping işlemlerimizi yapıcağız.
		//Configure adında (EntityTypeBuilder nesnesinden builder nesnesini oluşturduk.
		//ata çekirdek burası olacak.
		//Overlide edeceğimiz için virtual olarak tanımladık
		public virtual void Configure(EntityTypeBuilder<T> builder)
		{
			builder.HasKey(x => x.Id);//PrimaryKey'imiz id

			builder.Property(x => x.Status).IsRequired(true);
			builder.Property(x => x.CreateDate).IsRequired(true);
			builder.Property(x => x.CreatedBy).IsRequired(true);
			builder.Property(x => x.CreatedComputerName).IsRequired(true);
			builder.Property(x => x.CreatedIp).IsRequired(true);

			builder.Property(x => x.ModifiedIp).IsRequired(false);
			builder.Property(x => x.ModifiedDate).IsRequired(false);
			builder.Property(x => x.ModifiedComputerName).IsRequired(false);
			builder.Property(x => x.ModifiedBy).IsRequired(false);

		}
	}
}
