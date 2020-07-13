using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Omu.ValueInjecter;
using SoftwareProject.Associate.Dtos;
using SoftwareProject.Business.Services.Abstract;
using SoftwareProject.Business.UnitofWork.Abstract;
using SoftwareProject.Business.Validation.ValueInjector;
using SoftwareProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SoftwareProject.Business.Services.Concrete
{
    public class AppUserService : IAppUserService
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AppUserService(IUnitOfWork unitOfwork, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            this._unitOfwork = unitOfwork;
            this._mapper = mapper;
            this._webHostEnvironment = webHostEnvironment;
        }
       public void Add(UserDto model)
        {
            if (model.Image !=null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/user");
                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);//uploadDir mevcut değilse yarat.
                }
                string fileName = Path.GetFileName(model.Image.FileName);
                using(FileStream stream = new FileStream(Path.Combine(uploadDir, fileName),FileMode.Create))
                {
                    model.Image.CopyTo(stream);
                    model.ImagePath = fileName;//Db'de tutacağımız yaşatacağımız yer.
                }
            }

            AppUser appUser = _mapper.Map<AppUser>(model);
            _unitOfwork.User.Add(appUser);
            _unitOfwork.SaveChange();
        }

        public void Update(UserDto model)//hep id gönderirdik 
        {
            if (model.Image != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/user");
                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);//uploadDir mevcut değilse yarat.
                }
                string fileName = Path.GetFileName(model.Image.FileName);
                using (FileStream stream = new FileStream(Path.Combine(uploadDir, fileName), FileMode.Create))
                {
                    model.Image.CopyTo(stream);
                    model.ImagePath = fileName;//Db'de tutacağımız yaşatacağımız yer.
                }
            }

            AppUser appUser = _mapper.Map<AppUser>(model);
            appUser.InjectFrom<FilterId>(model);//eşleme işlemi yaptık=>ValueInjector klasöründe.
            _unitOfwork.User.Update(appUser);
            _unitOfwork.SaveChange();
        }

        public void Delete(Guid id)
        {
            //User'daki ıd zaten tostring parametre olarak gönderdiğimiz guid o yüzden tstring yapıyoruz.
            var user = _unitOfwork.User.Find(x => x.Id == id.ToString());
        }

        public IList<UserDto> GetFollowed(Guid id)
        {
            IList<UserDto> model = null;

            var user = _unitOfwork.User.Find(x => x.Id==id.ToString());//user'ı yakaladık.
            var followed = _unitOfwork.Follow.FindByList(x => x.FollowedId.ToString() == user.Id);

            List<AppUser> followedList = new List<AppUser>();

            foreach (var item in followed)
            {
                followedList.AddRange(_unitOfwork.User.FindByList(x => x.Id ==
                item.FollowedId.ToString()));

            }
            model = _mapper.Map<IList<UserDto>>(followedList).OrderBy(x => x.UserName).ToList();
            return model;

        }

        public IList<UserDto> GetFollower(Guid id)
        {
            IList<UserDto> model = null;
            var user = _unitOfwork.User.Find(x => x.Id == id.ToString());//user'ı yakaladık.
            var follower = _unitOfwork.Follow.FindByList(x => x.FollowerId.ToString() == user.Id);
            List<AppUser> followerList = new List<AppUser>();

            foreach (var item in follower)
            {
                followerList.AddRange(_unitOfwork.User.FindByList(x => x.Id ==
                item.FollowedId.ToString()));

            }
            model = _mapper.Map<IList<UserDto>>(followerList).OrderBy(x => x.UserName).ToList();
            return model;
        }
        public UserDto GetUserById(Guid id)
        {
            var user = _unitOfwork.User.Find(x => x.Id == id.ToString());
            UserDto model = _mapper.Map<UserDto>(user);
            return model;
        }

        public IList<UserDto> GetList()
        {
            var users = _unitOfwork.User.GetAll();
            IList<UserDto> model = _mapper.Map<IList<UserDto>>(users);
            return model;
        }

        
        public IList<UserDto> SearchList(string userName)
        {
            IList<UserDto> model = null;
            //Linq to SQL
            var users = from u in _unitOfwork.User.GetAll() select u;//Ram'e çıkarttık

            if (!String.IsNullOrWhiteSpace(userName))
            {
                users = users.Where(x => x.UserName.Contains(userName)).OrderBy(x => 
                x.UserName).ToList();//çıkardığımın üstünden filtreleme yaptık.
            }

            model = _mapper.Map<IList<UserDto>>(users);
            return model;
        }

        public bool IsFollowing(string userName_1, string userName_2)
        {
            var user_1 = _unitOfwork.User.Find(x => x.UserName == userName_1);
            var user_2 = _unitOfwork.User.Find(x => x.UserName == userName_2);

            var follower = _unitOfwork.Follow.FindByList(x => x.FollowedId.ToString() == user_1.Id);
            if (follower.Any(x=>x.FollowedId.ToString()==user_2.Id))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        
       
    }
}
