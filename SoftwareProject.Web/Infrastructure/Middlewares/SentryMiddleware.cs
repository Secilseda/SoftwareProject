using Microsoft.AspNetCore.Http;
using SoftwareProject.Web.Infrastructure.Sentry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareProject.Web.Infrastructure.Middlewares
{
    public class SentryMiddleware
    {
        //Middle şişmemesi adına dışarıya alıyoruz.
        private readonly RequestDelegate _next;//traginkten gelişyo iişlem bitti bi sonrakine geç mantığında.
        public SentryMiddleware(RequestDelegate next)//constracter mettotda enject ediyoruz.
        {
            this._next = next ?? throw new ArgumentNullException(nameof(next));
        }
        public Task Invoke(HttpContext httpContext, IErrorReporter errorReporter)
        {
            try
            {
                _next(httpContext);
            }
            catch (UnauthorizedAccessException ex)
            {

                throw new UnauthorizedAccessException(errorReporter.Capture(ex));
            }
            catch (Exception ex)
            {
                throw new Exception(errorReporter.Capture(ex));
            }
            return Task.CompletedTask;
        }
    }
}
