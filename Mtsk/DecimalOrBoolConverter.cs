using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mtsk
{
    internal sealed class DecimalOrBoolConverter : JsonConverter
    {
        private static readonly Type type = typeof(decimal?);

        public override bool CanConvert(Type objectType)
        {
            return objectType == type;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);

            switch (token.Type)
            {
                case JTokenType.Boolean:
                    return (decimal?)null;

                case JTokenType.Float:
                    return token.ToObject<decimal?>();

                default:
                    throw new NotSupportedException("The json was malformed.");
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }
}