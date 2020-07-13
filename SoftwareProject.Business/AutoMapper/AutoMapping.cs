using AutoMapper;
using SoftwareProject.Associate.Dtos;
using SoftwareProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareProject.Business.AutoMapper
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
			//Projeye dair bütün entityler burada mapping edilecek.
			//MAplenmiş halini değil dto halini çağırıyoruz.
			CreateMap<Post, PostDto>().ReverseMap();//sadece dto içerisine yazdığımız dto için mapping işlemlerini yapacağız.Mesela vm den liste halinde burda direk dtoyu alıyoruz.
			CreateMap<AppUser, UserDto>().ReverseMap();
			CreateMap<Comment, CommentDto>().ReverseMap();
			CreateMap<Like, LikeDto>().ReverseMap();
			CreateMap<AppUser, RegisterDto>().ReverseMap();
			CreateMap<AppUser, LoginDto>().ReverseMap();
		}

    }
}
