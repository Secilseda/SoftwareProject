using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SoftwareProject.Kernel.BaseResponce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareProject.Web.Infrastructure.ServiceExtension
{
    public static class FluentValidationService
    {
        public static void BuidFluentValidation(this IServiceCollection service)//services nesenmizi yarattık startup'taki gibi.
        {
            service.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var errors = context.ModelState.Values.SelectMany(x => x.Errors.Select(p => p.ErrorMessage)).Reverse().ToList();
                    var result = new KernelResponse
                    {
                        IsSuceess = false,
                        Messages = errors
                    };
                    return new BadRequestObjectResult(result);
                };

            });
        }
    }
}
