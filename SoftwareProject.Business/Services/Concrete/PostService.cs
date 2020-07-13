using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using SoftwareProject.Associate.Dtos;
using SoftwareProject.Business.Services.Abstract;
using SoftwareProject.Business.UnitofWork.Abstract;
using SoftwareProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareProject.Business.Services.Concrete
{
    public class PostService:IPostService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitofWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PostService(IMapper mapper, IUnitOfWork unitofWork, IWebHostEnvironment hostEnvironment)
        {
            this._mapper = mapper;
            this._unitofWork = unitofWork;
            this._hostEnvironment = hostEnvironment;
        }

        public void Add(PostDto model)
        {//controllerda yükü minimum'a indrimek için yazdık.
            var user = _unitofWork.User.Find(x => x.Id == model.UserId.ToString());

            if (model.Image != null)
            {
                //uploadDir=dosya dizini demek.wwroot'un altına açıcağımız media/post yolu verdik.
                string uploadDir = Path.Combine(_hostEnvironment.WebRootPath, "media/post");
                if (!Directory.Exists(uploadDir))//Exists değilse
                {
                    Directory.CreateDirectory(uploadDir);//directory'e hazırladı.
                }
                string fileName = Path.GetFileName(model.Image.FileName);//IFromFile tipinde bir parametreye ihtiyacımız var.
                using (FileStream stream = new FileStream(Path.Combine(uploadDir, fileName), FileMode.Create))
                {
                    model.Image.CopyTo(stream);
                    model.ImagePath = fileName;
                }
            }
            // alt yapıyı kurduk burada anlamında.Tek satırda database işlemini hallettik.
            Post postObj = _mapper.Map<Post>(model);
            _unitofWork.Post.Add(postObj);//post tablosuna add olucak.
            _unitofWork.SaveChange();


        }

        public void Delete(Guid id)
        {
            Post postObj = _unitofWork.Post.GetById(id);
            if (postObj != null)
            {
                _unitofWork.Post.Delete(postObj);
                _unitofWork.SaveChange();
            }
        }

        public PostDto Get(Guid id)
        {
            Post postObj = _unitofWork.Post.GetById(id);
            try
            {
                PostDto model = _mapper.Map<PostDto>(postObj);
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public IList<PostDto> GetPostByUser(Guid userId)
        {
            var post = _unitofWork.Post.FindByList(x => x.UserId == userId).OrderByDescending(x => x.CreateDate);
            IList<PostDto> model = _mapper.Map<IList<PostDto>>(post);//liste halşnde post dto'yu mapping işlemi yapıyoruz.

            return model;
        }

        public IList<PostDto> GetPosts()
        {
            var posts = _unitofWork.Post.GetAll().OrderByDescending(x => x.CreateDate);
            IList<PostDto> model = _mapper.Map<IList<PostDto>>(posts);
            return model;
        }


        public IList<PostDto> GetPostsByDate(DateTime startedDate, DateTime endDate)
        {
            var posts = _unitofWork.Post.FindByList(x => x.CreateDate == startedDate && x.CreateDate == endDate);
            IList<PostDto> model = _mapper.Map<IList<PostDto>>(posts);
            return model;
        }

        public void Update(PostDto model)
        {
            var user = _unitofWork.User.Find(x => x.Id == model.UserId.ToString());
            if (model.Image != null)
            {

                string uploadDir = Path.Combine(_hostEnvironment.WebRootPath, "media/post");
                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }
                string fileName = Path.GetFileName(model.Image.FileName);

                using (FileStream stream = new FileStream(Path.Combine(uploadDir, fileName), FileMode.Create))
                {
                    model.Image.CopyTo(stream);
                    model.ImagePath = fileName;
                }
            }

            Post postObj = _mapper.Map<Post>(model);
            _unitofWork.Post.Update(postObj);//post tablosuna add olucak.
            _unitofWork.SaveChange();
        }
    }
}
