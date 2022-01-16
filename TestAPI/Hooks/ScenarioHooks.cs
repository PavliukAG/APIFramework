using RestSharp;
using TechTalk.SpecFlow;
using TestCore.Configuration;
using TestCore.Extensions;

namespace TestAPI.Hooks
{
    [Binding]
    public class ScenarioHooks
    {
        private RestClient _client;
        private ScenarioContext _scenarioContext;

        public ScenarioHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _client.SetURL(Settings.BaseUrl, _scenarioContext);
        }
    }
}
