using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using CocoriCore;

namespace Ninja.Tmp1.Api
{
    public class ApplicationMiddleware
    {
        private readonly IRouter router;
        private readonly MessageDeserializer messageDeserializer;
        private readonly IMessageBus messageBus;
        private readonly IAppErrorBus errorBus;
        private readonly IHttpResponseWriter responseWriter;
        private readonly IHttpErrorWriter errorWriter;
        private readonly IAppTracer tracer;
        private readonly IClock clock;

        public ApplicationMiddleware(
            IRouter router,
            MessageDeserializer messageDeserializer,
            IMessageBus messageBus,
            IAppErrorBus errorBus,
            IHttpResponseWriter responseWriter,
            IHttpErrorWriter errorWriter,
            IAppTracer tracer,
            IClock clock
        )
        {
            this.router = router;
            this.messageDeserializer = messageDeserializer;
            this.messageBus = messageBus;
            this.errorBus = errorBus;
            this.responseWriter = responseWriter;
            this.errorWriter = errorWriter;
            this.tracer = tracer;
            this.clock = clock;
        }


        public async Task InvokeAsync(HttpContext httpContext, Func<Task> next)
        {
            await tracer.Start(httpContext, clock.Now);
            try
            {
                var route = router.TryFindRoute(httpContext.Request);
                if (route == null)
                {
                    throw new RouteNotFoundException(httpContext);
                }
                var message = await this.messageDeserializer.DeserializeMessageAsync<IMessage>(httpContext.Request, route);
                var response = await messageBus.ExecuteAsync(message);
                await responseWriter.WriteResponseAsync(response, httpContext.Response);
                await next();
            }
            catch (Exception exception)
            {
                await errorBus.HandleException(exception);
                await errorWriter.WriteErrorAsync(exception, httpContext.Response);
            }

            await tracer.Trace(httpContext, clock.Now);

        }
    }
}