using Microsoft.Extensions.Options;
using SharpRaven;
using SharpRaven.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareProject.Web.Infrastructure.Sentry
{
    public class SentryErrorReporter : IErrorReporter
    {
        private readonly IRavenClient _client;
        public SentryErrorReporter(IOptions<SentryOptions> options)
        {
            //if (options == null)
            //{
            //    throw new ArgumentNullException(typeof(options));//hata olarak =>ArgumentNullException fırlat.
            //}
            if (string.IsNullOrEmpty(options.Value.DNS))
            {
                //hata olarak =>ArgumentNullException fırlat.
                throw new ArgumentNullException("Can not construct a SentryErrorReporter witouth a valid DNS..!");
            }
            _client = new RavenClient(options.Value.DNS);
        }
        public string Capture(Exception exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }
            var refId = Guid.NewGuid().ToString().ToLower();
            var sentryEvent = new SentryEvent(exception);
            sentryEvent.Tags.Add("Referance Id:", refId);

            _client.Capture(sentryEvent);
            return refId;
        }

        public string Capture(string message)
        {
            if (string.IsNullOrEmpty(message))//IsNullOrEmpty kontrol ettik.
            {
                throw new ArgumentNullException(nameof(message));
            }
            var refId = Guid.NewGuid().ToString().ToLower();
            var sentryEvent = new SentryEvent(message);
            sentryEvent.Tags.Add("Referance Id:", refId);
            _client.Capture(new SentryEvent(message));
            return refId;
        }
    }
}
