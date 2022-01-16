using RestSharp;
using TechTalk.SpecFlow;
using TestCore.Constants;

namespace TestCore.Extensions
{
    public static class RequestExtensions
    {
        public static RestRequest CreateRequestWithMethod(this RestRequest request, string _request, Method _method, ScenarioContext _scenarioContext)
        {
            request = new RestRequest(_request, _method)
            {
                RequestFormat = DataFormat.Json
            };
            _scenarioContext.Remove(ClientConstants.Request);
            _scenarioContext.Add(ClientConstants.Request, request);
            return request;
        }

        public static RestRequest CreateRequestBody<T>(this RestRequest request, T body, ScenarioContext _scenarioContext)
        {
            _scenarioContext.Remove(ClientConstants.Body);
            _scenarioContext.Add(ClientConstants.Body, body);
            _scenarioContext.Get<RestRequest>(ClientConstants.Request).AddJsonBody(body);
            return request;
        }
    }
}
