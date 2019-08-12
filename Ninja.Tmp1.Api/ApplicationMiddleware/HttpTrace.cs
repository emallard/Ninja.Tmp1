using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace Ninja.Tmp1.Api
{
    public class HttpTrace
    {
        public DateTimeOffset Start;
        public DateTimeOffset End;
        public string Url;
        public string Protocol;
        public int StatusCode;

        public HttpTrace(HttpContext httpContext, DateTimeOffset start, DateTimeOffset end)
        {
            Start = start;
            End = end;
            Url = httpContext.Request?.GetDisplayUrl();
            Protocol = httpContext.Request?.Protocol;
            StatusCode = httpContext.Response != null ? httpContext.Response.StatusCode : 0;
        }

        public override string ToString()
        {
            return StatusCode + " " + Url + "  [" + Start + " - " + End + " ]";
        }
    }
}