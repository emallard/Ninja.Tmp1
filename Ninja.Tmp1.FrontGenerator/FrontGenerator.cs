using System;
using System.Linq;
using System.Reflection;
using CocoriCore;
using Xunit;

namespace Ninja.Tmp1.FrontGenerator
{
    public class FrontGenerator
    {
        [Fact]
        public void Main()
        {
            Console.WriteLine("Hello World!");
            var routerOptions = Ninja.Tmp1.Api.RouterConfiguration.Options();

            GeneratePage(typeof(Users_Connexion_PAGE), routerOptions);
            /*
            var allPages = Ninja.Tmp1.AssemblyInfo.Assembly
                .GetTypes()
                .Where(t => typeof(IPage).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
                .ToList();
            */
        }

        void GeneratePage(Type pageType, RouterOptions routerOptions)
        {
            Console.WriteLine("page : " + pageType.Name);

            var responseType = pageType.GetGenericArguments(typeof(IPage<>))[0];
            var fields = responseType.GetFields(BindingFlags.Instance | BindingFlags.Public);

            var gets = fields.Where(f => f.GetMemberType().IsAssignableTo(typeof(IGet))).ToList();
            foreach (var l in gets)
                Console.WriteLine("- get : " + l.GetMemberType().GetGenericArguments(typeof(IGet<>))[0]);

            var links = fields.Where(f => f.GetMemberType().IsAssignableTo(typeof(ILink))).ToList();
            foreach (var l in links)
                Console.WriteLine("- link : " + l.GetMemberType().GetGenericArguments(typeof(ILink<>))[0]);

            var forms = fields.Where(f => f.GetMemberType().IsAssignableTo(typeof(IForm))).ToList();
            foreach (var l in forms)
            {
                var genericArgs = l.GetMemberType().GetGenericArguments(typeof(Form<,,>));
                Console.WriteLine("- form : " + genericArgs[0] + ", " + genericArgs[1] + ", " + genericArgs[2]);
            }

            // trouver la route
            var pageRoute = routerOptions.AllRoutes.First(r => r.MessageType == pageType);
            var url = pageRoute.ParameterizedUrl;
        }
    }
}
