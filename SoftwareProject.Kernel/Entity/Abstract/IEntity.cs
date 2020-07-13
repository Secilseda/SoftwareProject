using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareProject.Kernel.Entity.Abstract
{
	public interface IEntity<T>//Belli olmayan bir tip demek
	{
		T Id { get; set; }//Esnek generic bir tiptir.
	}
}
