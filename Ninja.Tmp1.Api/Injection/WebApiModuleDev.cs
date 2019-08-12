using System;
using CocoriCore;
using Ninject.Extensions.NamedScope;
using Ninject.Modules;
using Newtonsoft.Json;
using Ninject.Extensions.ContextPreservation;
using Ninject;
using Jose;
using CocoriCore.TestUtils;

namespace Ninja.Tmp1.Api
{
    public class WebApiModuleDev : NinjectModule
    {
        public override void Load()
        {
            this.Bind<InMemoryEntityStore>().ToSelf().InSingletonScope();
            this.Bind<MemoryRepository>().ToSelf().InSingletonScope();
            this.Bind<IRepository>().To<MemoryRepository>().InNamedScope("unitofwork");
        }
    }
}
