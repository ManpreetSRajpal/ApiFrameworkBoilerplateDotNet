using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using ApiFrameworkCore.Model.Response;
using RestSharp;
using FluentAssertions;
using System.Net;

namespace APIFrameworkBoilerPlate.RestGetEndpoint
{
    [TestClass]
    public class TestGetEndpoint
    {

        private String getUrl = "https://reqres.in/api/users?page=2";

        [TestMethod]
        public void TestGetEndpointUsingRestSharp()
        {

            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(getUrl);
            RestResponse restResponse = restClient.Get(restRequest);
            Console.WriteLine("IsSuccessful - " + restResponse.StatusCode);

            Console.WriteLine(" Response Content " + restResponse.Content);



        }

        [TestMethod]
        public void TestGetEndpointInXml()
        {

            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(getUrl);
            restRequest.AddHeader("Accept", "application/xml");

            RestResponse restResponse = restClient.Get(restRequest);

            if (restResponse.IsSuccessful) {
                Console.WriteLine("IsSuccessful - " + restResponse.StatusCode);

                Console.WriteLine(" Response Content " + restResponse.Content);
            }


        }


        [TestMethod]
        public void TestGetEndpoint_WithDeserializer()
        {

            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(getUrl);
            restRequest.AddHeader("Accept", "application/json");

            RestResponse restResponse = restClient.Get(restRequest);
            var data = JsonSerializer.Deserialize<ListOfUsersRes>(restResponse.Content);


            if (restResponse.IsSuccessful) {

                Console.WriteLine(" O/P " + data.data.Count);

                Assert.AreEqual(200, (int)restResponse.StatusCode);
                Assert.AreEqual(6, (int)data.data.Count);


                Datum datum = data.data.Find(x => x.id == 9);

                Console.WriteLine(datum.email);

                Assert.AreEqual("Tobias", datum.first_name);

                Assert.IsTrue(datum.email.Contains("tobias"), "Element not present");


            }






        }


        [TestMethod]
        public void TestGetWithExecute() {

            RestClient client = new RestClient();
            RestRequest request = new RestRequest()
            {
                Method = Method.Get,
                Resource = getUrl
            };


            request.AddHeader("Accept", "application/json");

            RestResponse<ListOfUsersRes> restRespose = client.Execute<ListOfUsersRes>(request);

            Assert.AreEqual(200, (int)restRespose.StatusCode);

            Assert.IsNotNull(restRespose.Content, "Respnse is null");




        }


        [TestMethod]
        public void TestExecuteGet() {

            RestClient client = new RestClient();
            RestRequest request = new RestRequest(getUrl);



            RestResponse response = client.ExecuteGet(request);

            Console.WriteLine(response.Content);



        }


        [TestMethod]
        public void TestExecuteGetDeSerialize()
        {

            RestClient client = new RestClient();
            RestRequest restRequest = new RestRequest(getUrl);

            RestResponse<ListOfUsersRes> response= client.ExecuteGet<ListOfUsersRes>(restRequest);


            Datum datum
         =response.Data.data.Find(e => e.id == 9);

            Assert.IsTrue(datum.email.Contains("@"), "Not present");



               
        }

        [TestMethod]
        public void TestExecuteGetDeSerializeUsingFluentAssertions()
        {

            RestClient client = new RestClient();
            RestRequest restRequest = new RestRequest(getUrl);

            RestResponse<ListOfUsersRes> response = client.ExecuteGet<ListOfUsersRes>(restRequest);


            Datum datum
         = response.Data.data.Find(e => e.id == 9);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            datum.email.Contains("@");
                
                
                
                
                




        }

    }



}

