using System;
using Xunit;

namespace Vodafone.API.Tests
{
    public class Tests
    {
        [Fact]
        public void SendTest()
        {
            try
            {
                ApiClient.Init(
                    "apiUrl e dhene nga vodafone",
                    "Sender Name or Number",
                    "Username i dhene nga vodafone",
                    "Password i dhene nga llogarise");

                var sms = new Sms
                {
                    Recipients = new string[] { "nr telefonit venodset ketu", "numri i dyte" },
                    Message = "Mesazhi qe doni te dergoni vendset ketu",
                };

                var res = ApiClient.Send(sms);
                Assert.True(res == "OK", "Statusi i dergimit: " + res);
            }
            catch (Exception ex)
            {
                Assert.True(ex == null, ex.ToString());
            }
        }
    }
}