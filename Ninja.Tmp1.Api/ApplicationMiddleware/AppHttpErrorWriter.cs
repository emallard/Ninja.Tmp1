using System;
using System.Threading.Tasks;
using CocoriCore;
using Microsoft.AspNetCore.Http;

namespace Ninja.Tmp1.Api
{
    public class AppHttpErrorWriter : IHttpErrorWriter
    {
        private readonly RouteNotFoundExceptionWriter routeNotFoundExceptionWriter;
        private readonly DefaultExceptionWriter defaultExceptionWriter;

        public AppHttpErrorWriter(
            RouteNotFoundExceptionWriter routeNotFoundExceptionWriter,
            DefaultExceptionWriter defaultExceptionWriter
        )
        {
            this.routeNotFoundExceptionWriter = routeNotFoundExceptionWriter;
            this.defaultExceptionWriter = defaultExceptionWriter;
        }

        public async Task WriteErrorAsync(Exception exception, HttpResponse httpResponse)
        {
            var httpErrorContext = new HttpErrorWriterContext()
            {
                DebugMode = () => false,
                Exception = exception,
                HttpResponse = httpResponse,
                Data = null
            };

            if (exception is RouteNotFoundException)
                await routeNotFoundExceptionWriter.WriteResponseAsync(httpErrorContext);
            else
                await defaultExceptionWriter.WriteResponseAsync(httpErrorContext);
        }
    }
}
