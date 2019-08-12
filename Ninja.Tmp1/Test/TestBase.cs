using System;
using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Ninject;
using Ninject;
using Ninject.Extensions.ContextPreservation;
using Ninject.Extensions.NamedScope;

namespace Ninja.Tmp1
{
    public class TestBase
    {
        private StandardKernel kernel;

        public TestBase()
        {
            kernel = new StandardKernel();
            kernel.Load(new NamedScopeModule());
            kernel.Load(new ContextPreservationModule());
            kernel.Load(new CocoricoreNinjectModule());

            // Repository
            kernel.Bind<IInMemoryEntityStore>().To<InMemoryEntityStore>().InSingletonScope();
            kernel.Bind<IRepository>().To<MemoryRepository>().InNamedScope("unitofwork");

            // messagebus
            kernel.Bind<HandlerFinder>().ToConstant(new HandlerFinder(Ninja.Tmp1.AssemblyInfo.Assembly)).InSingletonScope();
            kernel.Bind<IMessageBus>().To<Ninja.Tmp1.MessageBus>().InNamedScope("unitofwork");

            kernel.Bind<IEmailSender>().To<Emails>().InSingletonScope();
            kernel.Bind<IEmailReader>().To<Emails>().InSingletonScope();

            kernel.Bind<IBrowser>().To<TestBrowser>();
            kernel.Bind<TestUser>().ToSelf();

        }
        public TestUser CreateUser()
        {
            return kernel.Get<TestUser>();
        }

        public IEmailReader GetEmailReader()
        {
            return kernel.Get<IEmailReader>();
        }
    }
}
