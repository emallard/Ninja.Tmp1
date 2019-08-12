using System;
using System.Linq;
using System.Reflection;
using CocoriCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Ninja.Tmp1.Api
{
    class CustomResolver : DefaultContractResolver
    {
        private readonly LinkConverter linkConverter;
        private readonly SubmitConverter submitConverter;

        public CustomResolver(LinkConverter linkConverter, SubmitConverter submitConverter) : base()
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
            if (objectType == typeof(ISubmit))
            {
                contract.Converter = submitConverter;
            }
            return contract;
        }
    }

    public class LinkConverter : JsonConverter
    {
        private readonly RouterOptions routerOptions;

        public LinkConverter(RouterOptions routerOptions)
        {
            this.routerOptions = routerOptions;
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(ILink).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new Exception("ILink Not supposed to be deserialized");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var link = (ILink)value;
            var route = routerOptions.AllRoutes.First(r => r.MessageType == link.GetMessage.GetType());
            writer.WriteValue(route.ParameterizedUrl);
            // replace with values in message
        }
    }


    public class SubmitConverter : JsonConverter
    {
        private readonly RouterOptions routerOptions;

        public SubmitConverter(RouterOptions routerOptions)
        {
            this.routerOptions = routerOptions;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(ISubmit).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new Exception("ISubmit Not supposed to be deserialized");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var submit = (ISubmit)value;
            var postRoute = routerOptions.AllRoutes.First(r => r.MessageType == submit.GetPostType());
            var redirectRoute = routerOptions.AllRoutes.First(r => r.MessageType == submit.GetRedirectMessage().GetType());
            writer.WriteStartObject();
            writer.WritePropertyName("verb");
            writer.WriteValue(postRoute.Method);
            writer.WritePropertyName("parameterizedUrl");
            writer.WriteValue(postRoute.ParameterizedUrl);
            writer.WritePropertyName("redirectParameterizedUrl");
            writer.WriteValue(redirectRoute.ParameterizedUrl);
            writer.WriteEndObject();
        }
    }

}