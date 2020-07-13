using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareProject.Business.Validation.ErrorResult
{
    public class ErrorModel
    {
        public string FielName { get; set; }//her bir error oluşturulduğunda bu kullanılacak.
        public string Message { get; set; }
    }
}
