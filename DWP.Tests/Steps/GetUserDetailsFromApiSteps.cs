using System.Net.Http;
using TechTalk.SpecFlow;
using RestSharp;
using Xunit;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using DWP.Tests.Helper;
using FluentAssertions;

namespace DWP.Tests.Steps
{
    [Binding]
    public sealed class GetUserDetailsFromApiSteps
    {
        private RestClient client;
        private RestRequest request;
        private IRestResponse response;

        [Given(@"I send GET request to the API with valid user id ""(.*)""")]
        public void GivenISendGETRequestToTheAPIWithValidUserId(string userId)
        {
            string targetUrl = string.Concat("http://bpdts-test-app-v2.herokuapp.com/user/", userId);
            client = new RestClient(targetUrl);
        }

        [When(@"I complete the request")]
        public void WhenICompleteTheRequest()
        {
            request = new RestRequest(Method.GET);
        }
                
        [Then(@"I receive status code (.*) and status description ""(.*)""")]
        public void ThenIReceiveStatusCodeAndStatusDescription(int expectedStatusCode, string expectedStatusDescription)
        {
            response = client.Execute(request);
            Assert.Equal(expectedStatusCode, (int)response.StatusCode);
            Assert.Equal(expectedStatusDescription, response.StatusDescription);
           
        }

        [Then(@"I receive ""(.*)"" as content type")]
        public void ThenIReceiveAsContentType(string expectedContentType)
        {
            response = client.Execute(request);
            Assert.Equal(expectedContentType, response.ContentType);

        }

        [Then(@"I read user first name as ""(.*)"" and last name as ""(.*)""")]
        public void ThenIReadUserFirstNameAsAndLastNameAs(string expectedFirstName, string expectedLastName)
        {
            response = client.Execute(request);
            if (response.IsSuccessful)
            {                
                    var user = JsonConvert.DeserializeObject<User>(response.Content);
                    user.FirstName.Should().Be(expectedFirstName);
                    user.LastName.Should().Be(expectedLastName);            
                     
            }           
        }

    }
}
