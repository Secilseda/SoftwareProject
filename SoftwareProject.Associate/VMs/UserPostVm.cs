using SoftwareProject.Associate.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareProject.Associate.VMs
{
    public class UserPostVm
    {
        public UserPostVm()
        {
            Posts = new List<PostDto>();
            Comments = new List<CommentDto>();
        }
        public List<PostDto> Posts { get; set; }
        public List<CommentDto> Comments { get; set; }
        public PostDto PostDto { get; set; }
    }
}
