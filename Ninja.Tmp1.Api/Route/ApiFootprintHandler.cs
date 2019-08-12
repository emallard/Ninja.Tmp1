using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using CocoriCore;
namespace Ervad.Api.WebApi
{

    public class ApiFootprintQuery : IQuery
    {
    }

    public class ApiFootprintHandler : QueryHandler<ApiFootprintQuery, ApiFootprint>
    {
        private readonly IRouter router;
        private readonly FootprintGenerator footprintGenerator;

        public ApiFootprintHandler(
            IRouter router)
        {
            this.router = router;
            this.footprintGenerator = new FootprintGenerator();
        }

        public override async Task<ApiFootprint> ExecuteAsync(ApiFootprintQuery query)
        {
            var routes = ((Router)this.router).AllRoutes;
            await Task.CompletedTask;
            return this.footprintGenerator.Generate(
                routes
                .Where(r => r.MessageType != typeof(ApiFootprintQuery))
                .Select(r => r.GetDescriptor()),
                Ninja.Tmp1.AssemblyInfo.Assembly
                );
        }
    }
}