using SmartParking.Share.Core;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SmartParking.Share.Contracts
{
    [Serializable]
    public sealed class ProblemDetails
    {
        [JsonPropertyName("detail")]
        public string Detail { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> Extensions { get; }

        [JsonPropertyName("instance")]
        public string Instance { get; set; }

        [JsonPropertyName("status")]
        public int? Status { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        public ProblemDetails()
        {
        }

        public ProblemDetails(HttpStatusCode? statusCode, string detail = null, string title = null, string instance = null, string type = null)
        {
            int num = (int)(statusCode.HasValue ? statusCode.Value : HttpStatusCode.BadRequest);
            Status = num;
            Title = title ?? "参数错误";
            Detail = detail;
            Instance = instance;
            Type = type ?? ("https://httpstatuses.com/" + num);
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, SystemTextJson.GetSnowGqzDefaultOptions());
        }
    }
}
