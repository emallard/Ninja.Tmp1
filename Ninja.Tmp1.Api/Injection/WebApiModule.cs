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
            this.Bind<IAppTracer>().To<AppTracer>();
            this.Bind<IAppErrorBus>().To<AppErrorBus>();
            this.Bind<IHttpErrorWriter>().To<AppHttpErrorWriter>().InSingletonScope();
            this.Bind<IHttpResponseWriter>().To<AppHttpResponseWriter>().InSingletonScope();
            //this.Bind<IUserService>().To<UserService>().InNamedScope("unitofwork");
            this.Bind<RouterOptions>().ToConstant(RouterConfiguration.Options());
            this.Bind<IRouter>().To<Router>().InSingletonScope();

            // Autres services
            var settings = new JsonSerializerSettings();

            this.Bind<JsonSerializer>().ToMethod(ctx =>
            {
                var serializer = new JsonSerializer();
                serializer.ContractResolver = ctx.GetContextPreservingResolutionRoot().Get<CustomResolver>();
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
