using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Ervad.Api.WebApi
{
    public class AppTracer : IAppTracer
    {
        public DateTimeOffset StartTime { get; private set; }

        public string TraceIdentifier { get; private set; }

        public async Task Start(HttpContext httpContext, DateTimeOffset time)
        {
            TraceIdentifier = Guid.NewGuid().ToString();
            StartTime = time;
            await Task.CompletedTask;
        }

        public async Task Trace(HttpContext httpContext, DateTimeOffset time)
        {
            var httpTrace = new HttpTrace(httpContext, StartTime, time);
            await Console.Out.WriteLineAsync(httpTrace.ToString());
        }
    }

}
