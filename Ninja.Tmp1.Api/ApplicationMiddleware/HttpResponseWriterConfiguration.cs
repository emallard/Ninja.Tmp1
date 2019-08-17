using CocoriCore;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ninja.Tmp1.Api
{
    public static class HttpResponseWriterConfiguration
    {
        public static HttpResponseWriterOptions Options()
        {
            var builder = new HttpResponseWriterOptionsBuilder();
            builder.For<FileResponse>().Call<HttpResponseWriterFileHandler>();
            //builder.For<IODataResponse>().Call<HttpResponseWriterODataHandler>();
            builder.For<ILink>().Call<LinkHttpResponseWriter>();
            builder.For<IForm>().Call<FormHttpResponseWriter>();
            builder.For<object>().Call<HttpResponseWriterDefaultHandler>();
            return builder.Options;
        }
    }
}
