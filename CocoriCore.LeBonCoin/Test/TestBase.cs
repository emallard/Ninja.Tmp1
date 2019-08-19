using System;
using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Ninject;
using CocoriCore.Page;
using Ninject;
using Ninject.Extensions.ContextPreservation;
using Ninject.Extensions.NamedScope;

namespace CocoriCore.LeBonCoin
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
            kernel.Bind<HandlerFinder>().ToConstant(new HandlerFinder(CocoriCore.LeBonCoin.AssemblyInfo.Assembly)).InSingletonScope();
            kernel.Bind<IMessageBus>().To<CocoriCore.LeBonCoin.MessageBus>().InNamedScope("unitofwork");

            kernel.Bind<IEmailSender>().To<Emails>().InSingletonScope();
            kernel.Bind<IEmailReader>().To<Emails>().InSingletonScope();

            kernel.Bind<IBrowser>().To<TestBrowser>();
            kernel.Bind<TestUser>().ToSelf();

        }
        public TestUser CreateUser()
        {
            return kernel.Get<TestUser>();
        }

        public TestBrowserFluent<int> CreateUserFluent()
        {
            return new TestBrowserFluent<int>(kernel.Get<TestBrowser>(), 0);
        }

        public IEmailReader GetEmailReader()
        {
            return kernel.Get<IEmailReader>();
        }
    }
}
