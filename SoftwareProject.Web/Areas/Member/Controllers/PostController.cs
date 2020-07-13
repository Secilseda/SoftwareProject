using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftwareProject.Associate.Dtos;
using SoftwareProject.Associate.VMs;
using SoftwareProject.Business.Services.Abstract;

namespace SoftwareProject.Web.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize]//sadece login kişi giricek. demk
    public class PostController : Controller
    {
        private readonly IAppUserService _appUserService;//repository yerini service aldı. Unitofwork yerine İşlerimiz artık service kısmında.
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;
        public PostController(IPostService postService, IAppUserService appUserService, ICommentService commentService)
        {
            this._postService = postService;
            this._appUserService = appUserService;
            this._commentService = commentService;
            //inject edicez.
            
        }

        public IActionResult Add()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Add(PostDto postDto)
        {
           _postService.Add(postDto);
            return View();
        }
        public IActionResult Show(UserPostVm userPostVm)//metotları göatericz.Sayfaya olduğu gibi dolucak.
        {
            userPostVm.Comments = _commentService.GetByPost(userPostVm.PostDto.Id).ToList();
            userPostVm.Posts = _postService.GetPosts().ToList();
            // listPost = _postService.GetPosts();//getirip listeyi haazırda bekşletir.
            return View(userPostVm);
        }

        public IActionResult Update(PostDto postDto)
        {
            _postService.Update(postDto);
            return View(postDto);
        }

        public IActionResult Delete(Guid id)
        {
            _postService.Delete(id);
            return View(id);
        }

    }
}
