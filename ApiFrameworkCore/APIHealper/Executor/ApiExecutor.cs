using System;
using ApiFrameworkCore.APIHealper.APIResponse;
using ApiFrameworkCore.Client;
using RestSharp;

namespace ApiFrameworkCore.APIHealper.Executor
{
    public class ApiExecutor : IExecutor
    {

        private  IClient _client;
        private  AbstractRequest _abstractRequest;

        public void SetApiExecutor(IClient client,AbstractRequest abstractRequest) {

            _client = client;
            _abstractRequest = abstractRequest;
        }

        public IResponse ExecuteRequest()
        {
            var client = _client.GetClient();
            var request = _abstractRequest.Build();
            var response = client.Execute(request);
            return new Response(response);


        }

        public IResponse<T> ExecuteRequest<T>()
        {
            var client = _client.GetClient();
            var request = _abstractRequest.Build();
            var response = client.Execute<T>(request);
            return new Response<T>(response);
        }
    }
}

