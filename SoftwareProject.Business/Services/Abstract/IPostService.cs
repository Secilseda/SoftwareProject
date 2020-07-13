using SoftwareProject.Associate.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareProject.Business.Services.Abstract
{
    public interface IPostService
    {
        //Her bir entity operasyonlarını ayarlayacağız.
        public void Add(PostDto model);
        public void Update(PostDto model);
        public void Delete(Guid id);

        public PostDto Get(Guid id);
        public IList<PostDto> GetPostByUser(Guid userId);
        public IList<PostDto> GetPosts();
        public IList<PostDto> GetPostsByDate(DateTime startedDate, DateTime endDate);//home'da bütün postları getiricez.

    }
}
