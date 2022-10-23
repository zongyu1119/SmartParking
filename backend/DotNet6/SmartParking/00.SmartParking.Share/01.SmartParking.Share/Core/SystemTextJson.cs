using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace SmartParking.Share.Core
{
    public static class SystemTextJson
    {
        public static JsonSerializerOptions GetSnowGqzDefaultOptions(Action<JsonSerializerOptions>? configOptions = null)
        {
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.Converters.Add(new DateTimeConverter());
            jsonSerializerOptions.Converters.Add(new DateTimeNullableConverter());
            jsonSerializerOptions.Encoder = GetSnowGqzDefaultEncoder();
            jsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
            jsonSerializerOptions.PropertyNameCaseInsensitive = true;
            jsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
            jsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            configOptions?.Invoke(jsonSerializerOptions);
            return jsonSerializerOptions;
        }

        public static JavaScriptEncoder GetSnowGqzDefaultEncoder()
        {
            return JavaScriptEncoder.Create(new TextEncoderSettings(UnicodeRanges.All));
        }
    }
}
