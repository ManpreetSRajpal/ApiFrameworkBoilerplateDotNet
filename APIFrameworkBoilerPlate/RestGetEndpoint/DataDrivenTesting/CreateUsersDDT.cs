using System;
using ApiFrameworkCore.APIHealper.APIRequest;
using ApiFrameworkCore.APIHealper.Executor;
using ApiFrameworkCore.Client;
using ApiFrameworkCore.Model.Request;
using ApiFrameworkCore.Model.Response;
using static ApiFrameworkCore.APIHealper.APIRequest.PostRequestBuilder;

namespace APIFrameworkBoilerPlate.RestGetEndpoint.DataDrivenTesting
{

	[TestClass]
	public class CreateUsersDDT
	{

        private TestContext testContext;

        public TestContext TestContext
        {

            get { return testContext; }
            set { testContext = value; }

        }

        private String postUrl = "https://reqres.in/api/users";
        private static IClient _client;
        private static ApiExecutor _apiExecutor;


        [ClassInitialize]
     
        public static void Setup(TestContext testContext)
        {
            _client = new Client();
            _apiExecutor = new ApiExecutor();

          

        }


        
        [DeploymentItem("TestData/CreateUser.csv"),
        DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "TestDaata/CreateUser.csv","CreateUser#csv",DataAccessMethod.Sequential)]
        [TestMethod]
        public void CreateUsersFromCsvSource()
		{

            CreateUsers createUsers = new CreateUsers();
            TestContext.DataRow["name"].ToString();

                

            var request = new PostRequestBuilder().WithUrl(postUrl)
                .WithBody<CreateUsers>(createUsers, RequestBodyType.JSON);

            _apiExecutor.SetApiExecutor(_client, request);

            var response=_apiExecutor.ExecuteRequest<CreateUserRes>();

            Console.WriteLine(" --- " + response.GetResponseData().name);
            Console.WriteLine(" --- " + response.GetResponseData().job);
            



		}

        [ClassCleanup]
        public static void tearDown()
        {
            _client.Dispose();
        }
    }
}

