using Omu.ValueInjecter.Injections;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareProject.Business.Validation.ValueInjector
{
    public class FilterId: LoopInjection
    {
        //Source'le target'ı birbirine eşitleyen bir yapıdır.
        //modelden gelenle filterıd'dekini birbiirne eşitleyecek.
        protected override bool MatchTypes(Type source, Type target)
        {
            return source.Name != "Id" && source.Name == target.Name && source.BaseType == target.BaseType;
        }
    }
}
