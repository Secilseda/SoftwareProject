using Microsoft.EntityFrameworkCore;
using SoftwareProject.Entities.Entity;
using SoftwareProject.Map.Mapping.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareProject.DataAccess.Context
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
		public DbSet<Post> Posts { get; set; }//referans istiyor farklı katmanda olduğu için.
		public DbSet<Like> Likes { get; set; }//referans istiyor farklı katmanda olduğu için.
		public DbSet<Comment> Comments { get; set; }//referans istiyor farklı katmanda olduğu için.
		public DbSet<AppUser> Users { get; set; }//referans istiyor farklı katmanda olduğu için.
		protected override void OnModelCreating(ModelBuilder modelBuilder)//override onmodel yazınca geliyor.
		{
			modelBuilder.ApplyConfiguration(new PostMap());
			modelBuilder.ApplyConfiguration(new LikeMap());
			modelBuilder.ApplyConfiguration(new CommentMap());
			modelBuilder.ApplyConfiguration(new UserMap<AppUser>());//tip aldığı için appuser'ı tip olarak verdk.

			base.OnModelCreating(modelBuilder);
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.EnableSensitiveDataLogging();
			//optionsBuilder.UseSqlServer(GetConnectionString());

			//==Layzloding Actication======
			//optionsBuilder.UseLazyLoadingProxies();
		}

		//private string GetConnectionString()
		//{
		//	//sabit belirtiyoruz.
		//	//appsetting ile startup ile uğraşmamak için sql'e bağlanma kodunu bu şekilde ö yazabiliriz
		//	const string databaseName = "GraduationProjectDb";

		//	return $"Server=localhost;" + $"Database={databaseName}" + $"Trusted_Connection=True;" + $"MultipleActiveResultsets=True;";
		//}

	}
}
