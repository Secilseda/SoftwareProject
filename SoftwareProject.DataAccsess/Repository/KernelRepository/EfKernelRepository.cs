using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SoftwareProject.DataAccess.Context;
using SoftwareProject.Kernel.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareProject.DataAccess.Repository.KernelRepository
{
	//T bir class olabilir demek.
	//IKernel repositoryı burada ayağa kaldırıyoruz yani metotlara burada işleme sokuyoruz.
	public class EfKernelRepository<T> : IKernelRepository<T> where T : class
	{
		private readonly ApplicationDbContext _context;
		protected DbSet<T> table;
		public EfKernelRepository(ApplicationDbContext context)
		{
			this._context = context;
			this.table = _context.Set<T>();
		}
		public void Add(T item)
		{
			 table.Add(item);
		}

		public bool Any(Expression<Func<T, bool>> exp)
		{
			return table.Any(exp);//exp bul tabloya ekle
		}

		public void Delete(T item)
		{
			table.Remove(item);//tamamen kaldırılacak.
		}

		public T Find(Expression<Func<T, bool>> exp)
		{
			return table.Where(exp).FirstOrDefault();
		}

		public ICollection<T> FindByList(Expression<Func<T, bool>> exp)
		{
			return table.Where(exp).ToList();
		}

		public ICollection<T> GetAll()
		{
			return table.ToList();
		}

		public T GetById(Guid id)
		{
			return table.Find(id);
		}

		public void Update(T item)
		{
			table.Update(item);
		}
	}
}
