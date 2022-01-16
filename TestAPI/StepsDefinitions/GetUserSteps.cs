using RestSharp;
using TechTalk.SpecFlow;
using TestCore.Extensions;

namespace TestAPI.StepsDefinitions
{
    [Binding]
    public class GetUserSteps
    {
        private ScenarioContext _scenarioContext;
        private readonly IRestResponse _response;

        public GetUserSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Then(@"I should get in response user with '(.*)' name")]
        public void ThenIShouldGetInResponseUserWithName(string name)
        {
            _response.VerifyResponseBodyContains(name, _scenarioContext);
        }

    }
}
