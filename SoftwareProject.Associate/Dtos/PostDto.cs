using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SoftwareProject.Associate.Dtos
{
   public class PostDto:BaseDto
    {
		[Required]
		public string Content { get; set; }
		[FileExtensions]
		public string ImagePath { get; set; }
		public Guid UserId { get; set; }

		[NotMapped]
		public IFormFile Image { get; set; }
	}
}
