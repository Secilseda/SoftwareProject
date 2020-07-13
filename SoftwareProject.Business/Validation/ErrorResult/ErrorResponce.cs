using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareProject.Business.Validation.ErrorResult
{
    public class ErrorResponce
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
