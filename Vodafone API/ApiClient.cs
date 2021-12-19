using System.Net;
using System.Text;

namespace Vodafone.API;

public static class ApiClient
{
    public static string ApiUrl { get; private set; }
    public static string Username { get; private set; }
    public static string Password { get; private set; }

    /// <summary>
    /// Initialize the client with api endpoint, username and password for your account
    /// </summary>
    /// <param name="apiUrl"></param>
    /// <param name="username"></param>
    /// <param name="password"></param>
    public static void Init(string apiUrl, string username, string password)
    {
        if (string.IsNullOrEmpty(apiUrl))
            throw new Exception("API URL null");

        if (string.IsNullOrEmpty(username))
            throw new Exception("Username null or empty");

        if (string.IsNullOrEmpty(password))
            throw new Exception("Password null or empty");

        ApiUrl = apiUrl;
        Username = username;
        Password = password;
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
                SenderId = sms.SenderId,
                Recipients = sms.Recipients,
                Message = sms.Message,
                DLRURL = "https://app.deal-group.al/statuscallback?id=13354"
            };

            var json = System.Text.Json.JsonSerializer.Serialize(request);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
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
