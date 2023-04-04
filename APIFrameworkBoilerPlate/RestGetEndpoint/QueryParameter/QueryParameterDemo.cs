using System;
using ApiFrameworkCore.APIHealper.APIRequest;
using ApiFrameworkCore.APIHealper.Executor;
using ApiFrameworkCore.Client;
using FluentAssertions;
using RestSharp;

namespace APIFrameworkBoilerPlate.RestGetEndpoint.QueryParameter
{

    [TestClass]
    public class QueryParameterDemo
    {

        private String getUrl = "https://reqres.in/api/users";
        private static IClient _client;
        private static ApiExecutor apiExecutor;


        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            _client = new Client();
            apiExecutor = new ApiExecutor();
        }


        [TestMethod]
        public void QueryParameter_WithoutFramework() {

            RestClient client = new RestClient();

            RestRequest restRequest = new RestRequest()
            {
                Resource = getUrl,
                Method = Method.Get


            };

            restRequest.AddParameter("page",1);

            RestResponse restResponse= client.ExecuteGet(restRequest);

            Console.WriteLine(" --- " + restResponse.Content);

            restResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);


        }


        [TestMethod]
        public void QueryParameter_WithFramework() {

            var headers=new Dictionary<string,string>
            {
                { "accpet","application/json"}

            };

            var queryParameter = new Dictionary<string, string>
            {

                {"page","3" }
            };

            AbstractRequest abstractRequest = new GetRequestBuilder().WithHeader(headers)
                .WithQueryParameter(queryParameter)
                .WithUrl(getUrl);

            apiExecutor.SetApiExecutor(_client, abstractRequest);

            var response=apiExecutor.ExecuteRequest();

            Console.WriteLine(" ------ " + response.GetResponseData());


        }



        [ClassCleanup]
        public static void TearDown()
        {
            _client.Dispose();
        }



    }
}

