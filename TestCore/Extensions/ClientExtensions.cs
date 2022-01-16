using RestSharp;
using System;
using TechTalk.SpecFlow;
using TestCore.Constants;

namespace TestCore.Extensions
{
    [Binding]
    public static class ClientExtensions
    {
        public static RestClient GetClient(this RestClient client, ScenarioContext _scenarioContext)
        {
            try
            {
                client = _scenarioContext.Get<RestClient>(ClientConstants.Client);
            }
            catch (Exception)
            {
                client = new RestClient();
            }
            return client;
        }

        public static RestClient SetURL(this RestClient client, string url, ScenarioContext _scenarioContext)
        {
            client = GetClient(client, _scenarioContext);
            client.BaseUrl = new Uri(url);
            _scenarioContext.Remove(ClientConstants.Client);
            _scenarioContext.Add(ClientConstants.Client, client);
            return client;
        }
    }
}
