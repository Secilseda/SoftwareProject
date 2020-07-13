using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareProject.Associate.Dtos
{
    public class LoginDto:BaseDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
