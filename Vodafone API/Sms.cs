using System.Text.Json.Serialization;

namespace Vodafone.API
{
    public class Sms
    {
        /// <summary>
        /// Recepients array to whom sms will be delivered.
        /// </summary>
        public string[] Recipients { get; set; }

        /// <summary>
        /// Message text to be delivered
        /// </summary>
        public string Message { get; set; }
    }
}