using SoftwareProject.Kernel.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareProject.Entities.Entity
{
	public class Post:KernelEntity
	{
        public string Content { get; set; }
        public string ImagePath { get; set; }

        //Not:Update=1
        //Her postun bir tane kullanıcısı olmak zorundadır.
        public Guid UserId { get; set; }
        public virtual AppUser User { get; set; }

        //Not=Update=2 hayata geçirilicek.
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        
    }
}
