using SoftwareProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareProject.Associate.Dtos
{
    public class CommentDto:BaseDto
    {
        public string Content { get; set; }

        public Guid UserId { get; set; }
        public virtual AppUser User { get; set; }

        public Guid PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
