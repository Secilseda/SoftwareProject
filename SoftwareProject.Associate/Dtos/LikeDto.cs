using SoftwareProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareProject.Associate.Dtos
{
    public class LikeDto:BaseDto
    {
        public Guid UserId { get; set; }
        public virtual AppUser User { get; set; }

        public Guid PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
