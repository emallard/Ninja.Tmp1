using System;
using CocoriCore;
using Ninject.Extensions.NamedScope;
using Ninject.Modules;
using Ninja.Tmp1;
using Newtonsoft.Json;
using Ninject.Extensions.ContextPreservation;
using Ninject;
using Jose;
using CocoriCore.TestUtils;

namespace Ninja.Tmp1.Api
{
    public class WebApiModule : NinjectModule
    {
        public override void Load()
        {


            this.Bind<HandlerFinder>().ToConstant(
                new HandlerFinder(
                    Ninja.Tmp1.AssemblyInfo.Assembly,
                    this.GetType().Assembly))
                .InSingletonScope();

            this.Bind<IMessageBus>().To<Ninja.Tmp1.MessageBus>().InNamedScope("unitofwork");


            // Middleware
            this.Bind<ApplicationMiddleware>().ToSelf();
            this.Bind<MessageDeserializer>().ToSelf();
            this.Bind<IErrorBus>().To<MyErrorBus>().InNamedScope("unitofwork");

            this.Bind<IHttpErrorWriter>().To<HttpErrorWriter>().InSingletonScope();
            this.Bind<HttpErrorWriterOptions>().ToConstant(HttpErrorWriterConfiguration.Options());
            //builder.RegisterAssemblyTypes(cocoriCoreAssembly, apiAssembly).AssignableTo<IHttpErrorWriterHandler>().AsSelf();

            this.Bind<IHttpResponseWriter>().To<HttpResponseWriter>().InSingletonScope();
            this.Bind<HttpResponseWriterOptions>().ToConstant(HttpResponseWriterConfiguration.Options());
            // builder.RegisterAssemblyTypes(cocoriCoreAssembly, cocoriCoreODataAssembly, apiAssembly).AssignableTo<IHttpReponseWriterHandler>().AsSelf();

            this.Bind<ITracer>().To<Tracer>();

            //this.Bind<IUserService>().To<UserService>().InNamedScope("unitofwork");
            this.Bind<RouterOptions>().ToConstant(RouterConfiguration.Options());
            this.Bind<IRouter>().To<Router>().InSingletonScope();

            // Autres services
            var settings = new JsonSerializerSettings();

            this.Bind<JsonSerializer>().ToMethod(ctx =>
            {
                var serializer = new JsonSerializer();
                serializer.Converters.Add(ctx.GetContextPreservingResolutionRoot().Get<LinkConverter>());
                serializer.Converters.Add(ctx.GetContextPreservingResolutionRoot().Get<FormConverter>());
                return serializer;
            }).InSingletonScope();
            this.Bind<IClock>().To<Clock>().InSingletonScope();

            /*
            this.Bind<JWTConfiguration>().ToConstant(new JWTConfiguration("monsecret", JwsAlgorithm.ES256));
            this.Bind<ITokenService>().To<TokenService>().InSingletonScope();
            this.Bind<IHttpAuthenticator, IClaimsProvider>().To<JwtAuthenticator>().InNamedScope("unitofwork");
            */
        }
    }
}
