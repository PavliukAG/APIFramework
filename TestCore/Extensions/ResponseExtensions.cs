using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Net;
using System.Threading;
using TechTalk.SpecFlow;
using TestCore.Constants;

namespace TestCore.Extensions
{
    public static class ResponseExtensions
    {
        public static IRestResponse SendTheRequest(this IRestResponse response, ScenarioContext _scenarioContext)
        {
            response = _scenarioContext.Get<RestClient>(ClientConstants.Client).Execute(_scenarioContext.Get<RestRequest>(ClientConstants.Request));
            int code = ((int)response.StatusCode);
            int tries = 0;
            while(code == 0 && tries < 10)
            {
                Thread.Sleep(3000);
                response = _scenarioContext.Get<RestClient>(ClientConstants.Client).Execute(_scenarioContext.Get<RestRequest>(ClientConstants.Request));
                code = ((int)response.StatusCode);
                tries += 1;
            }
            _scenarioContext.Remove(ClientConstants.Response);
            _scenarioContext.Add(ClientConstants.Response, response);
            return response;
        }

        public static IRestResponse VerifyResponseStatusCode(this IRestResponse response, int status, ScenarioContext _scenarioContext)
        {
            var code = ((int)_scenarioContext.Get<RestResponse>(ClientConstants.Response).StatusCode);
            Assert.AreEqual(status, code, $"Response status was: {code}, but expected {status}.");
            return response;
        }

        public static IRestResponse VerifyResponseStatusCode(this IRestResponse response, HttpStatusCode status, ScenarioContext _scenarioContext)
        {
            var code = (_scenarioContext.Get<RestResponse>(ClientConstants.Response).StatusCode);
            Assert.AreEqual(status, code, $"Response status was: {code}, but expected {status}.");
            return response;
        }

        public static IRestResponse VerifyResponseBodyContains(this IRestResponse response, string expextedMessage, ScenarioContext _scenarioContext)
        {
            JsonDeserializer deserializer = new JsonDeserializer();
            var message = deserializer.Deserialize<string>(_scenarioContext.Get<RestResponse>(ClientConstants.Response));
            Assert.IsTrue(message.Contains(message), $"{message}");
            return response;
        }
    }
}
