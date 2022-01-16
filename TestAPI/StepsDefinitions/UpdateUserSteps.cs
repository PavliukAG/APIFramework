using RestSharp;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestCore.Extensions;

namespace TestAPI.StepsDefinitions
{
    [Binding]
    public class UpdateUserSteps
    {
        private RestRequest _request;
        private readonly ScenarioContext _scenarioContext;

        public UpdateUserSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I add the following request body for updating user")]
        public void GivenIAddTheFollowingRequestBodyForUpdatingUser(Table userDetailsTable)
        {
            var user = userDetailsTable.CreateInstance<CreateUserSteps>();
            _request.CreateRequestBody(user, _scenarioContext);
        }

    }
}
