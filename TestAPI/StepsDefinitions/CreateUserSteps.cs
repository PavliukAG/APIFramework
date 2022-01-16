using NUnit.Framework;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestAPI.Models;
using TestCore.Constants;
using TestCore.Extensions;

namespace TestAPI
{
    [Binding]
    public class CreateUserSteps
    {
        private RestRequest _request;
        private RestResponse _response;
        private ScenarioContext _scenarioContext;

        public CreateUserSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Then(@"user with '(.*)' name is created")]
        public void ThenUserWithNameIsCreated(string name)
        {
            var apiResponse = _scenarioContext.DeserializeFromResponse<CreateUserResponse>();
            Assert.AreEqual(name, apiResponse.Name, "Valid user is not created.");
        }

        [Then(@"I save user id")]
        public void ThenISaveUserId()
        {
            CreateUserResponse apiResponse = _scenarioContext.DeserializeFromResponse<CreateUserResponse>();
            _scenarioContext.Add("UserId", apiResponse.Id);
        }

        [Given(@"I have next user")]
        public void GivenIHaveNextUser(Table userDetailTable)
        {
            var request = userDetailTable.CreateInstance<CreateUserRequest>();
            _request.CreateRequestWithMethod(Endpoints.CreateUser, Method.POST, _scenarioContext);
            _request.CreateRequestBody(request, _scenarioContext);
            _response.SendTheRequest(_scenarioContext);
            _response.VerifyResponseStatusCode(HttpStatusCode.Created, _scenarioContext);
        }

        [Given(@"I update created user")]
        public void GivenIUpdateCreatedUser(Table userDetailsTable)
        {
            var request = userDetailsTable.CreateInstance<CreateUserRequest>();
            var userId = _scenarioContext.Get<int>("UserId");
            _request.CreateRequestWithMethod(string.Format(Endpoints.UpdateUser, userId), Method.PUT, _scenarioContext);
            _request.CreateRequestBody(request, _scenarioContext);
            _response.SendTheRequest(_scenarioContext);
            _response.VerifyResponseStatusCode(HttpStatusCode.OK, _scenarioContext);
        }

        [Then(@"user with '(.*)' job is updated")]
        public void ThenUserWithJobIsUpdated(string job)
        {
            var apiResponse = _scenarioContext.DeserializeFromResponse<CreateUserResponse>();
            Assert.AreEqual(job, apiResponse.Job, "Valid user is not updated.");
        }

    }
}
