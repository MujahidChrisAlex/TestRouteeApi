using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;

namespace TestSendSmsAPI
{

    public class Base
    {

        private string MyToken { get; set; }
        private JObject MyObj { get; set; }


        public void GenerateToken()
        {
            var client = new RestClient("https://auth.routee.net/oauth/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("authorization", "Basic NjExZjQ5MjA3YTg0ZWUwMDAxMzQzYjBiOjBNOFUzVGJkcmw=");
            request.AddParameter("application/x-www-form-urlencoded", "grant_type=client_credentials", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            JObject obs = JObject.Parse(response.Content);
            string token = "Bearer " + (obs["access_token"].ToString());


            MyToken = token;
        }


        public void PostWithBody()
        {
            var client = new RestClient("https://connect.routee.net/sms");
            var request = new RestRequest(Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", MyToken);
            request.AddParameter("application/json", "{ \"body\": \"A new game has been posted to the MindPuzzle. Check it out\",\"to\" : \"+3004418453\",\"from\": \"JazzTelecom\"}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            JObject obs = JObject.Parse(response.Content);
            MyObj = obs;

        }


        public void VerifyResponseMessageTxt()
        {
            Assert.That(MyObj["developerMessage"].ToString(), Is.EqualTo("Insufficient Balance"), "API response is not correct");

        }


        public void VerifyStatusCode()
        {

            Assert.That(MyObj["code"].ToString(), Is.EqualTo("400001009"), "API status code is incorrect");

        }

    }
}
