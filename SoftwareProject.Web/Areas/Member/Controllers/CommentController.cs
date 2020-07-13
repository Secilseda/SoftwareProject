using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoftwareProject.Associate.Dtos;
using SoftwareProject.Business.Services.Abstract;

namespace SoftwareProject.Web.Areas.Member.Controllers
{
    public class CommentController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;
        public CommentController(IAppUserService appUserService, IPostService postService, ICommentService commentService)
        {
            this._postService = postService;
            this._appUserService = appUserService;
            this._commentService = commentService;
        }
        public IActionResult Add(CommentDto commentDto)
        {
            _commentService.Add(commentDto);
            return View();
        }
        public IActionResult Delete(Guid id)
        {
            _commentService.Delete(id);
            return View(id);

        }

        public IActionResult GetbyId(Guid id)
        {
          var commentlist = _commentService.GetByPost(id);

            return View(commentlist);
        }
        public IActionResult GetAll()
        {
            _commentService.GetAll();
            return View();
        }

        public IActionResult GetbyUser(Guid id)
        {
            var postlist = _commentService.GetByUser(id);
            return View(postlist);
        }
        public IActionResult Get(Guid id)
        {
            var list =_commentService.Get(id);
            return View(list);
        }
    }
}
