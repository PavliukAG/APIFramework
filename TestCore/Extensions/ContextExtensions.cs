using RestSharp;
using TechTalk.SpecFlow;
using TestCore.Constants;

namespace TestCore.Extensions
{
    public static class ContextExtensions
    {
        public static string GetResponseContent(this ScenarioContext scenarioContext) => scenarioContext.Get<RestResponse>(ClientConstants.Response).Content;

        public static T DeserializeFromResponse<T>(this ScenarioContext scenarioContext) => scenarioContext.GetResponseContent().Deserialize<T>();
    }
}
