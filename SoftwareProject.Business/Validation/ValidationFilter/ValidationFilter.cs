using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SoftwareProject.Business.Validation.ErrorResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareProject.Business.Validation.ValidationFilter
{
    public class ValidationFilter : IAsyncActionFilter
    {
        //Validasyonlar ne işimize yarar=>Güvenlik içindir.Error mesajlarımızı iletir.Hepsini bir noktadan yürütmek için Custom bir fileextension oluşturduk onlara uymasını istedik.
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)//ModelState.IsValid durumunu burada handle edicez.modele uygun değilse
            {
                //yani bir error varsa.
                var errorInModelState = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(x => x.Key, y => y.Value.Errors.Select(z =>
                    z.ErrorMessage)).ToArray();

                ErrorResponce errorResponce = new ErrorResponce();

                foreach (var error in errorInModelState)//birinci adımdayken
                {
                    foreach (var subError in error.Value)//bu bütün errorler için dönecek.
                    {
                        ErrorModel errorModel = new ErrorModel
                        {
                            FielName = error.Key,
                            Message = subError
                        };
                        //Birinci tur bittiğinde buraya uğrayacak.
                        errorResponce.Errors.Add(errorModel);
                    }

                }
                context.Result = new BadRequestObjectResult(errorResponce);//yarattık doldurduk errorResponce döndürdük.
            }
            await next();
        }
    }
}
