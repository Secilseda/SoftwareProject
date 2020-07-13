using SoftwareProject.DataAccess.Context;
using SoftwareProject.DataAccess.Repository.Abstract;
using SoftwareProject.DataAccess.Repository.KernelRepository;
using SoftwareProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareProject.DataAccess.Repository.Concrete
{
	public class EfPostRepository:EfKernelRepository<Post>,IPostRepository
	{
		public EfPostRepository(ApplicationDbContext applicationDbContext):base (applicationDbContext)
		{

		}
	}
}
