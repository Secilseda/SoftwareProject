using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareProject.Associate.Dtos
{
    public class RegisterDto:BaseDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
