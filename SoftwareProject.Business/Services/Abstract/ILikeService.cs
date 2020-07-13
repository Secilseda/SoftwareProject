using SoftwareProject.Associate.VMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareProject.Business.Services.Abstract
{
     public interface ILikeService
    {
        JsonLikeVM Like(Guid id, string userName);
    }
}
