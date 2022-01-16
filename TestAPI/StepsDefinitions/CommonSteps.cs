using RestSharp;
using TechTalk.SpecFlow;
using TestCore.Extensions;

namespace TestAPI
{
    [Binding]
    public class CommonSteps
    {
        private RestRequest _request;
        private IRestResponse _response;
        private ScenarioContext _scenarioContext;

        public CommonSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I create a request to endpoint '(.*)' with '(.*)' method")]
        public void GivenICreateARequestToEndpointWithMethod(string endpoint, Method method)
        {
            _request.CreateRequestWithMethod(endpoint, method, _scenarioContext);
        }

        [When(@"I send the request")]
        public void WhenISendTheRequest()
        {
            _response.SendTheRequest(_scenarioContext);
        }

        [Then(@"I should see status code '(.*)'")]
        public void ThenIShouldSeeStatusCode(int code)
        {
            _response.VerifyResponseStatusCode(code, _scenarioContext);
        }
    }
}
