using SoftwareProject.Kernel.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareProject.Entities.Entity
{
    public class Comment:KernelEntity
    {
        //Her bir commentin bağlı olduğu Guid bir postu  .
        public string Content { get; set; }

        public Guid UserId { get; set; }
        public virtual AppUser User { get; set; }


        public Guid PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
