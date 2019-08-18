using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CocoriCore.Page
{

    public class SammyJsGeneratorOptions
    {
        public string OutputPath;
    }

    public class SammyJsGenerator
    {
        private readonly SammyJsGeneratorOptions options;
        private readonly PageInspector pageInspector;
        private readonly TypescriptFormatter typescriptFormatter;

        public SammyJsGenerator(
            SammyJsGeneratorOptions options,
            PageInspector pageInspector,
            TypescriptFormatter typescriptFormatter)
        {
            this.options = options;
            this.pageInspector = pageInspector;
            this.typescriptFormatter = typescriptFormatter;
        }

        public void Generate()
        {
            // copy cocoricore.page.fetch.ts

            if (!Directory.Exists(System.IO.Path.Combine(options.OutputPath, "javascripts")))
                Directory.CreateDirectory(System.IO.Path.Combine(options.OutputPath, "javascripts"));

            File.WriteAllText(
                System.IO.Path.Combine(options.OutputPath, "javascripts", "pages.ts"),
                GeneratePagesTs());

            File.WriteAllText(
                System.IO.Path.Combine(options.OutputPath, "javascripts", "routes.js"),
                GenerateRoutesJs());
        }

        private string GeneratePagesTs()
        {
            Console.WriteLine("pages.ts");

            var pageTypeInfos = pageInspector.GetPageTypeInfos();

            var formattedPageTypes = pageTypeInfos
                .Select(p => typescriptFormatter.FormatType(p))
                .ToArray();

            Console.WriteLine("pages : \n" + string.Join("", pageTypeInfos.Select(x => $"  - {x.Name} \n")));

            var formattedNeededTypes = pageTypeInfos
                .SelectMany(p => pageInspector.GetNeededTypeInfos(p))
                .Select(p => typescriptFormatter.FormatType(p))
                .ToArray();

            return string.Join("", formattedNeededTypes)
                + string.Join("", formattedPageTypes);
        }

        private string GenerateRoutesJs()
        {
            Console.WriteLine("routes.js");

            var routesAndNames = pageInspector.GetPageTypeInfos()
                        .Select(x => new
                        {
                            Route = x.PageUrl.Replace("/api/page", ""),
                            Name = x.Name
                        })
                        .ToArray();

            Console.WriteLine(string.Join("", routesAndNames.Select(x => $"  - {x.Route} : {x.Name} \n")));

            return
                "function addRoutes(app) {\n"
                + string.Join("",
                    routesAndNames
                        .Select(x =>
                            "app.addPage(\"" + x.Route + "\", " + x.Name + ");\n"
                        ))
                + "}";
        }
        /*
                private IEnumerable<PathAndText> GenerateTemplates()
                {
                    var pageTypeInfos = pageInspector
                    .GetPageTypeInfos()
                    .Select(x => x.PageUrl);

                }
        */
    }

}
