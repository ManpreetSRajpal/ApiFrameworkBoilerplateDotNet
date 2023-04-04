using System;
using RestSharp;
using FluentAssertions;
using System.Net;
using ApiFrameworkCore.Model.Request;
using ApiFrameworkCore.Client;
using ApiFrameworkCore.APIHealper.Executor;
using ApiFrameworkCore.APIHealper.APIRequest;
using static ApiFrameworkCore.APIHealper.APIRequest.PostRequestBuilder;
using ApiFrameworkCore.Model.Response;

namespace APIFrameworkBoilerPlate.RestGetEndpoint.PostEndpoint
{

	[TestClass]
	public class TestPostRequestWithFramework
	{

		private string postUrl = "https://reqres.in/api/users";
		private static IClient _client;
		private static ApiExecutor _apiExecutor;


        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            _client = new Client();
            _apiExecutor = new ApiExecutor();

        }

        [TestMethod]
		public void TestPostRequestWithFramework_JsonAsString() {


			string jsonData = "{\n    \"name\": \"Manpreet\",\n    \"job\": \"leader\"\n}";

            var request = new PostRequestBuilder().WithUrl(postUrl)
                .WithBody<String>(jsonData, RequestBodyType.STRING);

            _apiExecutor.SetApiExecutor(_client, request);
            var response=_apiExecutor.ExecuteRequest();


            Console.WriteLine(response.GetResponseData());

		}

        [TestMethod]
        public void TestPostRequestWithFramework_JsonObject()
        {

            CreateUsers jsonData = new CreateUsers();

            jsonData.names = "Manpreet";
            jsonData.job = "QAT";

            var request = new PostRequestBuilder().WithUrl(postUrl).WithBody<CreateUsers>(jsonData, RequestBodyType.JSON);

            _apiExecutor.SetApiExecutor(_client, request);

            var response = _apiExecutor.ExecuteRequest<CreateUserRes>();

            Console.WriteLine(response.GetResponseData());

        }

        [ClassCleanup]
        public static void tearDown()
        {
            _client.Dispose();
        }

    }

}

