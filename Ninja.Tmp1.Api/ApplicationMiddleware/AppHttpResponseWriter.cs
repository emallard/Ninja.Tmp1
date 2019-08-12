using System.IO;
using System.Threading.Tasks;
using CocoriCore;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Ninja.Tmp1.Api
{
    public class AppHttpResponseWriter : IHttpResponseWriter
    {
        private readonly JsonSerializer jsonSerializer;
        private readonly HttpResponseWriterFileHandler httpResponseWriterFileHandler;

        public AppHttpResponseWriter(
            JsonSerializer jsonSerializer,
            HttpResponseWriterFileHandler httpResponseWriterFileHandler
        )
        {
            this.jsonSerializer = jsonSerializer;
            this.httpResponseWriterFileHandler = httpResponseWriterFileHandler;
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
            else
            {
                using (var stringWriter = new StringWriter())
                {
                    httpResponse.ContentType = "application/json; charset=utf-8";
                    jsonSerializer.Serialize(stringWriter, response);
                    await httpResponse.WriteAsync(stringWriter.ToString());
                }
            }
        }
    }
}
