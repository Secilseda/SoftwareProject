using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareProject.Kernel.Repository.Abstract
{
	public interface IKernelRepository<T>//Generic bir tip olacak.
	{

		bool Any(Expression<Func<T, bool>> exp);

		//temel crud işlemlerimizin metotlarıdır.
		void Add(T item);
		void Update(T item);
		void Delete(T item);

		T GetById(Guid id);
		T Find(Expression<Func<T, bool>> exp);

		ICollection<T> GetAll();
		//diğer metotları diğer projelerden alabilirsin bu projede az kullandık.
		//her entity için tek bir metot yerine bir metot her entity için yazdık.Linq to alıyor içerisine.
		ICollection<T> FindByList(Expression<Func<T, bool>> exp);
	}
}
