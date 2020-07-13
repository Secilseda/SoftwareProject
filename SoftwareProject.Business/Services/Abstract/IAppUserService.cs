using SoftwareProject.Associate.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareProject.Business.Services.Abstract
{
    public interface IAppUserService
    {
        //Chat yapılınca bunu listeleyebiliriz.(getonlineFried listeleme)
        public void Add(UserDto model);
        public void Update(UserDto model);
        public void Delete(Guid id);
        
        public IList<UserDto> GetFollowed(Guid id);
        public IList<UserDto> GetFollower(Guid id);

        public UserDto GetUserById(Guid id);
        public IList<UserDto> GetList();

        public IList<UserDto> SearchList(string userName);

        public bool IsFollowing(string userName_1, string userName_2);

    }
}
