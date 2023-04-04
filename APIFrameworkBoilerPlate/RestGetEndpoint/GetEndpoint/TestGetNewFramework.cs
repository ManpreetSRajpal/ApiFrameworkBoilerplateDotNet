using System;
using System.Net;
using ApiFrameworkCore.APIHealper.APIRequest;
using ApiFrameworkCore.APIHealper.Executor;
using ApiFrameworkCore.Client;
using FluentAssertions;



namespace APIFrameworkBoilerPlate.RestGetEndpoint
{

	[TestClass]
	public class TestGetNewFramework
	{
        private String getUrl = "https://reqres.in/api/users?page=2";
        private  static IClient _client;
		private  static ApiExecutor apiExecutor;


		[ClassInitialize]
		public static void Setup(TestContext testContext)
		{
			_client = new Client();
			apiExecutor = new ApiExecutor();

		}

		[TestMethod]
		public void GetRequestWithApiHealper() {
			
			var headers = new Dictionary<string, string> {
				{ "Accept","application/json" }
			};

			AbstractRequest abstractRequest = new GetRequestBuilder()
				.WithUrl(getUrl)
				.WithHeader(headers);


			apiExecutor.SetApiExecutor(_client, abstractRequest);
			var response=apiExecutor.ExecuteRequest();


			response.GethttpStatusCode().Should().Be(HttpStatusCode.OK);
			Console.WriteLine(response.GetResponseData());
		}


		[ClassCleanup]
		public static void tearDown()
		{
			_client.Dispose();
		}
	}
}

