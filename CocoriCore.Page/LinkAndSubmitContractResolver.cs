using System;
using System.Reflection;
using CocoriCore;
using Newtonsoft.Json.Serialization;

namespace CocoriCore
{
    public class CustomResolver : DefaultContractResolver
    {
        private readonly LinkConverter linkConverter;
        private readonly FormConverter submitConverter;

        public CustomResolver(LinkConverter linkConverter, FormConverter submitConverter) : base()
        {
            this.linkConverter = linkConverter;
            this.submitConverter = submitConverter;
        }

        protected override JsonContract CreateContract(Type objectType)
        {
            JsonContract contract = base.CreateContract(objectType);
            /*
            if (objectType.IsGenericType && objectType.GetGenericTypeDefinition()
                    == typeof(ILink<>))
            {
                Type itemType = type.GetGenericArguments()[0]; // use this...
            }*/

            if (objectType == typeof(ILink))
            {
                contract.Converter = linkConverter;
            }
            if (objectType == typeof(IForm))
            {
                contract.Converter = submitConverter;
            }
            return contract;
        }
    }

}