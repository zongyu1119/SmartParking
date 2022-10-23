using System.Text.Json;
using System.Text.Json.Serialization;

namespace SmartParking.Share.Core
{
    public class DateTimeNullableConverter : JsonConverter<DateTime?>
    {
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            DateTime? result = null;
            if (DateTime.TryParse(reader.GetString(), out var result2))
            {
                result = result2;
            }

            return result;
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.ToString("yyyy-MM-dd HH:mm:ss"));
        }
    }
}
