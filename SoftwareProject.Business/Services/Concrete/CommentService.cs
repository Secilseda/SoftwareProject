using AutoMapper;
using Omu.ValueInjecter;
using SoftwareProject.Associate.Dtos;
using SoftwareProject.Business.Services.Abstract;
using SoftwareProject.Business.UnitofWork.Abstract;
using SoftwareProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareProject.Business.Services.Concrete
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IMapper _mapper;
        public CommentService(IUnitOfWork unitOfwork, IMapper mapper)
        {
            this._unitOfwork = unitOfwork;
            this._mapper = mapper;
        }
        public void Add(CommentDto model)
        {
            Comment comment = new Comment();

            var commentObj = _mapper.Map<Comment>(model);
            _unitOfwork.Comment.Add(commentObj);
            _unitOfwork.SaveChange();

        }

        public void Delete(Guid id)
        {
            var comment = _unitOfwork.Comment.GetById(id);
            if (comment != null)
            {
                _unitOfwork.Comment.Delete(comment);
                _unitOfwork.SaveChange();
            }
        }

        public CommentDto Get(Guid id)
        {
            var comment = _unitOfwork.Comment.GetById(id);
            CommentDto commentDto = new CommentDto();
            commentDto.InjectFrom(comment);
            return commentDto;
        }

        public IList<CommentDto> GetAll()
        {
            var comment = _unitOfwork.Comment.GetAll();
            var model = _mapper.Map<IList<CommentDto>>(comment);
            return model;
        }

        public IList<CommentDto> GetByPost(Guid id)
        {
            var comment = _unitOfwork.Comment.FindByList(x => x.PostId == id).OrderByDescending(x => x.CreateDate).Take(5);
            var model = _mapper.Map<IList<CommentDto>>(comment);
            return model;
        }

        public IList<CommentDto> GetByUser(Guid id)
        {
            var comment = _unitOfwork.Comment.FindByList(x => x.UserId == id);
            var model = _mapper.Map<IList<CommentDto>>(comment);
            return model;
        }
    }
}
