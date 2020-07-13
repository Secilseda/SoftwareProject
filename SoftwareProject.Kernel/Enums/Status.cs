using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareProject.Kernel.Enums
{
	public enum Status
	{
		//Enum index mantığı ile çalışır. 
		//İlk değeri sıfırdır.
		None,
		Active,
		Modified,
		Passive
		//Passive'in amacı database'den veriyi silmemek ama kullanıcıya da göstermemek adına, kullanıcının silmek istediği veriyi passive hale getiriyoruz.
	}
}
