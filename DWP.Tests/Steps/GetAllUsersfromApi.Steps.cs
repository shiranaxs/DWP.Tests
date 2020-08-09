using Newtonsoft.Json;
using TechTalk.SpecFlow;
using RestSharp;
using System.Collections.Generic;
using DWP.Tests.Helper;
using Xunit;


namespace DWP.Tests.Steps
{
    [Binding]
    public sealed class GetAllUsersfromApi
    {
        private RestClient client;
        private RestRequest request;
        private IRestResponse response;

        [Given(@"I send GET request to get all users")]
        public void GivenISendGETRequestToGetAllUsers()
        {
            string targetUrl = "http://bpdts-test-app-v2.herokuapp.com/users";
            client = new RestClient(targetUrl);
        }

        [When(@"I complete the request for all users")]
        public void WhenICompleteTheRequestForAllUsers()
        {
            request = new RestRequest(Method.GET);
        }

        [Then(@"Api returns ""(.*)"" users")]
        public void ThenApiReturnsUsers(int expectedUserCount)
        {
            response = client.Execute(request);
            if (response.IsSuccessful)
            {              
                    var users = JsonConvert.DeserializeObject<List<UserList>>(response.Content);
                    Assert.Equal(expectedUserCount,users.Count);                
            }
        }

    }
}
