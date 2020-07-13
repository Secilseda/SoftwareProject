using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareProject.Web.Infrastructure.Sentry
{
    public interface IErrorReporter
    {
        string Capture(Exception exception);//yakala demek.
        string Capture(string message);
    }
}
