using System.Threading.Tasks;
using CocoriCore;
using Microsoft.AspNetCore.Http;

namespace Ervad.Api.WebApi
{
    public class AppHttpResponseWriter : IHttpResponseWriter
    {
        private readonly HttpResponseWriterFileHandler httpResponseWriterFileHandler;
        private readonly HttpResponseWriterDefaultHandler httpResponseWriterDefaultHandler;

        public AppHttpResponseWriter(
            HttpResponseWriterFileHandler httpResponseWriterFileHandler,
            HttpResponseWriterDefaultHandler httpResponseWriterDefaultHandler
        )
        {
            this.httpResponseWriterFileHandler = httpResponseWriterFileHandler;
            this.httpResponseWriterDefaultHandler = httpResponseWriterDefaultHandler;
        }

        public async Task WriteResponseAsync(object response, HttpResponse httpResponse)
        {
            var context = new HttpResponseWriterContext()
            {
                Response = response,
                HttpResponse = httpResponse
            };

            if (response is FileResponse)
                await httpResponseWriterFileHandler.WriteResponseAsync(context);
            /*
            else if (response is LogInResponse)
            {
                context.Response = new {Token = ((LogInResponse) response).UserId};
                await httpResponseWriterDefaultHandler.WriteResponseAsync(context);
            }
            */
            else 
                await httpResponseWriterDefaultHandler.WriteResponseAsync(context);
        }
    }
}
