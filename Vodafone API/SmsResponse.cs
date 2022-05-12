using System.Text.Json.Serialization;

namespace Vodafone.API
{
    public class SmsResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("error")]
        public string Error { get; set; }
    }
}