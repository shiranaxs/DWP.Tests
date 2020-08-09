using Newtonsoft.Json;
using TechTalk.SpecFlow;
using RestSharp;
using System.Collections.Generic;
using DWP.Tests.Helper;
using Xunit;


namespace DWP.Tests.Steps
{
    [Binding]
    public sealed class GetCityDetailsFromApiSteps
    {
        private RestClient client;
        private RestRequest request;
        private IRestResponse response;

        [Given(@"I send GET request to the City API with valid city name ""(.*)""")]
        public void GivenISendGETRequestToTheCityAPIWithValidCityName(string cityName)
        {
            string targetUrl = string.Concat("http://bpdts-test-app-v2.herokuapp.com/city/", cityName,"/users");
            client = new RestClient(targetUrl);
        }

        [When(@"I complete the request for city API")]
        public void WhenICompleteTheRequestForCityAPI()
        {
            request = new RestRequest(Method.GET);
            response = client.Execute(request);
        }

        [Then(@"API returns available users located in ""(.*)""")]
        public void ThenAPIReturnsAvailableUsersLocatedIn(string p0)
        {
            if (response.IsSuccessful)
            {
                try
                {
                    var users = JsonConvert.DeserializeObject<List<UserList>>(response.Content);
                    Assert.True(users.Count > 0);
                }
                catch
                {
                    throw new System.Exception("An error occured during the object serialization!");
                }

            }
        }


    }
}
