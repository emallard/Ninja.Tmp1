using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CocoriCore;

namespace CocoriCore.Page
{

    public class PageInspector
    {
        private readonly RouterOptions routerOptions;

        public PageInspector(RouterOptions routerOptions)
        {
            this.routerOptions = routerOptions;
        }

        public IEnumerable<FrontTypeInfo> GetPageTypeInfos()
        {
            return GetPageTypes()
                    .Select(r => GetPageTypeInfo(r))
                    .ToList();
        }

        public IEnumerable<Type> GetPageTypes()
        {
            return routerOptions.AllRoutes
                    .Where(r => r.MessageType.IsAssignableTo(typeof(IPage)))
                    .Select(r => r.MessageType)
                    .ToList();
        }

        public FrontTypeInfo GetPageTypeInfo(Type pageType)
        {
            var pageResponseType = GetPageResponseType(pageType);
            var typeInfo = new FrontTypeInfo();
            typeInfo.Name = pageType.Name;
            typeInfo.IsPage = true;
            typeInfo.PageUrl = GetPageParameterizedUrl(pageType);
            typeInfo.FieldInfos = GetFields(pageResponseType);
            typeInfo.LinkMemberInfos = GetLinks(pageResponseType);
            typeInfo.FormMemberInfos = GetForms(pageResponseType);
            return typeInfo;
        }

        public IEnumerable<FrontTypeInfo> GetNeededTypeInfos(FrontTypeInfo pageTypeInfo)
        {
            var neededTypes = pageTypeInfo.FormMemberInfos
                                .SelectMany(f => new Type[] { f.MessageType, f.ResponseType })
                                .Concat(pageTypeInfo.FieldInfos
                                    .Where(f => f.FieldType != typeof(string))
                                    .Select(f => f.FieldType)
                                    .ToList()
                                )
                                .Distinct()
                                .ToList();

            return neededTypes.Select(type => new FrontTypeInfo()
            {
                Name = type.Name,
                IsPage = false,
                FieldInfos = GetFields(type),
                LinkMemberInfos = GetLinks(type)
            });
        }

        public string GetPageParameterizedUrl(Type pageType)
        {
            var route = routerOptions.AllRoutes.First(r => r.MessageType == pageType);
            return route.ParameterizedUrl;
        }

        public Type GetPageResponseType(Type pageType)
        {
            return pageType.GetGenericArguments(typeof(IPage<>))[0];
        }

        public List<FieldInfo> GetFields(Type type)
        {
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);

            return fields
                .Where(f => !f.GetMemberType().IsAssignableTo(typeof(ILink))
                        && !f.GetMemberType().IsAssignableTo(typeof(IForm))
                        && !f.GetMemberType().IsAssignableTo(typeof(IGet))
                        )
                .ToList();
        }

        public List<LinkMemberInfo> GetLinks(Type type)
        {
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);

            return fields
                .Where(f => f.GetMemberType().IsAssignableTo(typeof(ILink)))
                .Select(l => new LinkMemberInfo() { Name = l.Name })
                .ToList();
        }

        public List<FormMemberInfo> GetForms(Type type)
        {
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);

            return fields
                .Where(f => f.GetMemberType().IsAssignableTo(typeof(IForm)))
                .Select(f =>
                {
                    var generics = f.GetMemberType().GetGenericArguments(typeof(Form<,>));
                    return new FormMemberInfo
                    {
                        Name = f.Name,
                        MessageType = generics[0],
                        ResponseType = generics[1]
                    };
                })
                .ToList();
        }
    }
}
