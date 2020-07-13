using Microsoft.AspNetCore.Http;
using SoftwareProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SoftwareProject.Associate.Dtos
{
    public class UserDto:BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        [FileExtensions]
        public string ImagePath { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        
    }
}
