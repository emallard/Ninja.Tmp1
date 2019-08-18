using System;
using CocoriCore;
using Ninject.Extensions.NamedScope;
using Ninject.Modules;
using CocoriCore.LeBonCoin;
using Newtonsoft.Json;
using Ninject.Extensions.ContextPreservation;
using Ninject;
using Jose;
using CocoriCore.TestUtils;

namespace CocoriCore.LeBonCoin.Api
{
    public class WebApiModuleRecette : NinjectModule
    {
        public override void Load()
        {
            this.Bind<InMemoryEntityStore>().ToSelf().InSingletonScope();
            this.Bind<MemoryRepository>().ToSelf().InSingletonScope();
            this.Bind<IRepository>().To<MemoryRepository>().InNamedScope("unitofwork");
        }
    }
}
