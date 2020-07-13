using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareProject.Associate.Dtos
{
    public class BaseDto
    {
        //Diğer bütün Data Transfer Object'lere miras verecek ortak özellikler burada öbeklenebilir.
        public Guid Id { get; set; }
    }
}
