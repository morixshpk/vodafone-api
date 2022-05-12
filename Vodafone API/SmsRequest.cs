using System;
using System.Text.Json.Serialization;

namespace Vodafone.API
{

    public class SmsRequest
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("senderId")]
        public string SenderId { get; set; }

        [JsonPropertyName("recipients")]
        public string[] Recipients { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("dlr-url")]
        public string DLRURL { get; set; }
    }

}