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
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace APIFrameworkBoilerPlate.RestGetEndpoint.PostEndpoint
{

    [TestClass]
    public class TestWithJsonPath
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
        public void TestWithJsonPath_Demo()
        {

            CreateUsers jsonData = new CreateUsers();

            jsonData.names = "Manpreet";
            jsonData.job = "QAT";

            var request = new PostRequestBuilder().WithUrl(postUrl).WithBody<CreateUsers>(jsonData, RequestBodyType.JSON);

            _apiExecutor.SetApiExecutor(_client, request);

            var response = _apiExecutor.ExecuteRequest();

            Console.WriteLine(response.GetResponseData());

            // PArse the Json document
            JObject jObject = JObject.Parse(response.GetResponseData());

            // use the jsonpath
            // and type caste the result
            var job=jObject.SelectToken("$.job");

         }


        [TestMethod]
        public void TestJsonObjectInModel()
        {

            CreateUsers jsonData = new CreateUsers();

            jsonData.names = "Manpreet";
            jsonData.job = "QAT";

            var request = new PostRequestBuilder().WithUrl(postUrl).WithBody<CreateUsers>(jsonData, RequestBodyType.JSON);

            _apiExecutor.SetApiExecutor(_client, request);

            var response = _apiExecutor.ExecuteRequest();

            Console.WriteLine(response.GetResponseData());

            // Parse the Json document
            JObject jObject = JObject.Parse(response.GetResponseData());

            // use the jsonpath
            // and type caste the result
            var job = jObject.SelectToken("$.job");

            CreateUserRes createUser = JsonSerializer.Deserialize<CreateUserRes>(job.ToString());

            Console.WriteLine(createUser.id);

            //createUser.id.Should().Be(40);

        }

        [ClassCleanup]
        public static void tearDown()
        {
            _client.Dispose();
        }

    }

}

