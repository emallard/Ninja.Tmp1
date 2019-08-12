using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Ninja.Tmp1.Api
{
    public interface IAppTracer
    {
        string TraceIdentifier { get; }
        Task Start(HttpContext httpContext, DateTimeOffset time);
        Task Trace(HttpContext httpContext, DateTimeOffset time);
    }
}