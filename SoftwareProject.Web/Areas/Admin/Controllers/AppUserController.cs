using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftwareProject.Associate.Dtos;
using SoftwareProject.Business.Services.Abstract;

namespace SoftwareProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AppUserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;

        public AppUserController(IAppUserService appUserService,
            IPostService postService, ICommentService commentService)
        {
            this._postService = postService;
            this._appUserService = appUserService;
            this._commentService = commentService;
        }
        
        [HttpPost]
        public IActionResult Add(UserDto model)
        {
            _appUserService.Add(model);
            return RedirectToAction("List");
        }
        public IActionResult Update(UserDto model)
        {
            _appUserService.Update(model);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _appUserService.Delete(id);
            return View(id);
        }
    }
        
}
