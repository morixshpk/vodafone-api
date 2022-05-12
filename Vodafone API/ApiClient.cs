using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Vodafone.API
{
    public static class ApiClient
    {
        public static string ApiUrl { get; private set; }
        public static string SenderId { get; set; }
        public static string Username { get; private set; }
        public static string Password { get; private set; }

        /// <summary>
        /// Initialize the client with api endpoint, username and password for your account
        /// </summary>
        /// <param name="apiUrl">Endpoint where request/response are made</param>
        /// <param name="senderId">Id of the sender. Name or phone number</param>
        /// <param name="username">Username to login at API URL</param>
        /// <param name="password">Password to login at API URL</param>
        public static void Init(string apiUrl, string senderId, string username, string password)
        {
            if (string.IsNullOrEmpty(apiUrl))
                throw new Exception("API URL null");

            if (string.IsNullOrEmpty(apiUrl))
                throw new Exception("SenderId null");

            if (string.IsNullOrEmpty(username))
                throw new Exception("Username null or empty");

            if (string.IsNullOrEmpty(password))
                throw new Exception("Password null or empty");

            ApiUrl = apiUrl;
            SenderId = senderId;
            Username = username;
            Password = password;

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        /// <summary>
        /// Return OK if message delivered;
        /// </summary>
        /// <param name="sms"></param>
        /// <returns></returns>
        public static string Send(Sms sms)
        {
            string response;
            try
            {
                var request = new SmsRequest
                {
                    Username = Username,
                    Password = Password,
                    SenderId = SenderId,
                    Recipients = sms.Recipients,
                    Message = sms.Message,
                    DLRURL = "https://morix.al/statuscallback?id=" + DateTime.Now.Ticks
                };

                var jsonRequest = System.Text.Json.JsonSerializer.Serialize(request);
                var data = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                var client = new HttpClient();
                var result = client.PostAsync(ApiUrl, data).Result;
                string jsonResponse = result.Content.ReadAsStringAsync().Result;

                var res = System.Text.Json.JsonSerializer.Deserialize<SmsResponse>(jsonResponse);

                if (res != null && string.IsNullOrEmpty(res.Id) == false)
                    response = "OK";
                else if (string.IsNullOrEmpty(res.Error) == false)
                    response = res.Error;
                else
                    response = "Not sent";
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }

            return response;
        }
    }
}