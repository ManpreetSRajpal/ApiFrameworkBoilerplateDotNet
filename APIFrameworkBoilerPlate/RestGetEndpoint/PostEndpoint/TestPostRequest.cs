using System;
using RestSharp;
using FluentAssertions;
using System.Net;
using ApiFrameworkCore.Model.Request;

namespace APIFrameworkBoilerPlate.RestGetEndpoint.PostEndpoint
{

	[TestClass]
	public class TestPostRequest
	{

		private string postUrl = "https://reqres.in/api/users";

		[TestMethod]
		public void TestPostRequestWithJsonAsString() {


			string jsonData = "{\n    \"name\": \"morpheus\",\n    \"job\": \"leader\"\n}";

			// Create the client

			RestClient client = new RestClient();

			// Create the Request

			RestRequest request = new RestRequest()
			{
				Resource = postUrl,
				Method = Method.Post
			};


			// Add the body to the request

			request.AddStringBody(jsonData, DataFormat.Json);


			// Send the request

			RestResponse resposne = client.ExecutePost(request);

			resposne.StatusCode.Should().Be(HttpStatusCode.Created);


		}

        [TestMethod]
        public void TestPostRequestWithJsonObject(){


            CreateUsers jsonData = new CreateUsers();

			jsonData.names = "Manpreet";
            jsonData.job = "QA";


            // Create the client

            RestClient client = new RestClient();

            // Create the Request

            RestRequest request = new RestRequest()
            {
                Resource = postUrl,
                Method = Method.Post
            };


            // Add the body to the request

            request.AddJsonBody(jsonData);

			RestResponse response=client.ExecutePost(request);

			response.StatusCode.Should().Be(HttpStatusCode.Created);

        }

    }

}

