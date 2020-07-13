using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Identity;
using SoftwareProject.Kernel.Enums;

namespace SoftwareProject.Entities.Entity
{
    public class AppUser:IdentityUser
    {
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string Password { get; set; }
		//sen doldur kendi projende.
		//Image koy.EMail vs vs

		//=====Kernel entity'den gelen entity'leri eklemek gerekmektedir.

		public DateTime CreateDate { get; set; }
		public string CreatedComputerName { get; set; }
		public string CreatedBy { get; set; }
		public string CreatedIp { get; set; }


		public DateTime? ModifiedDate { get; set; }
		public string ModifiedComputerName { get; set; }
		public string ModifiedIp { get; set; }
		public string ModifiedBy { get; set; }//kim tarafından modified edildi.


		public Status Status { get; set; }
		//===================

		public virtual ICollection<Post> Posts { get; set; }//Virrtual yazmamız lazyloading'le ilgili.
		public virtual ICollection<Comment> Comments { get; set; }
		public virtual ICollection<Like> Likes { get; set; }
	
		
	}
}
