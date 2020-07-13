using SoftwareProject.Associate.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareProject.Business.Services.Abstract
{
    public interface ICommentService
    {
        void Add(CommentDto model);
        void Delete(Guid id);

        IList<CommentDto> GetAll();
        IList<CommentDto> GetByPost(Guid id);
        IList<CommentDto> GetByUser(Guid id);

        CommentDto Get(Guid id);
    }
}
