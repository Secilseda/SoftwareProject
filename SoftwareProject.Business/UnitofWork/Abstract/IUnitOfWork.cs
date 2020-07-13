using SoftwareProject.DataAccess.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareProject.Business.UnitofWork.Abstract
{
    public interface IUnitOfWork: IDisposable
    {
        IPostRepository Post { get; }
        ICommentRepository Comment { get; }
        ILikeRepository Like { get; }
        IAppUserRepository User { get; }
        void SaveChange();
        
    }
}
