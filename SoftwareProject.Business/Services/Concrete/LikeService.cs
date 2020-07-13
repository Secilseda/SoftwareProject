using SoftwareProject.Associate.VMs;
using SoftwareProject.Business.Services.Abstract;
using SoftwareProject.Business.UnitofWork.Abstract;
using SoftwareProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareProject.Business.Services.Concrete
{
    public class LikeService : ILikeService
    {
        private readonly IUnitOfWork _unitOfwork;
        public LikeService(IUnitOfWork unitOfwork)
        {
            this._unitOfwork = unitOfwork;
        }
        public JsonLikeVM Like(Guid id, string userName)//script yazılacak bunun için.
        {
            JsonLikeVM js = new JsonLikeVM();
            Post post = _unitOfwork.Post.GetById(id);
            AppUser user = _unitOfwork.User.Find(x => x.UserName == userName);
            if (post != null)
            {
                if (!(_unitOfwork.Like.Any(x => x.UserId.ToString() == user.Id && x.PostId == post.Id)))
                {
                    Like like = new Like();
                    like.PostId = post.Id;
                    like.UserId = Guid.Parse(user.Id);
                    _unitOfwork.Like.Add(like);
                    _unitOfwork.SaveChange();

                    js.Likes = _unitOfwork.Like.FindByList(x => x.PostId == post.Id).Count();
                    return js;
                }
                else
                {
                    Like like = _unitOfwork.Like.Find(x => x.PostId == post.Id && x.UserId.ToString() == user.Id);
                    _unitOfwork.Like.Delete(like);
                    _unitOfwork.SaveChange();
                    js.Likes = _unitOfwork.Like.FindByList(x => x.PostId == post.Id).Count();
                    return js;
                }
            }
            else
            {
                js.Likes = 0;
                return js;
            }
        }
    }
}
