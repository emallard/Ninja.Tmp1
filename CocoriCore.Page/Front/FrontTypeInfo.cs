using System.Collections.Generic;
using System.Reflection;

namespace CocoriCore.Page
{
    public class FrontTypeInfo
    {
        public string Name;
        public List<FieldInfo> FieldInfos;
        public bool IsPage;
        public string PageUrl;
        public List<LinkMemberInfo> LinkMemberInfos;
        public List<FormMemberInfo> FormMemberInfos;
    }
}
