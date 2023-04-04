using System;
using ApiFrameworkCore.APIHealper.APIResponse;
using ApiFrameworkCore.Client;
using RestSharp;

namespace ApiFrameworkCore.APIHealper.Executor
{
    public class Executor : IExecutor
    {

        private readonly IClient _client;
        private readonly AbstractRequest _abstractRequest;

        public Executor(AbstractRequest request, IClient client) {

            _abstractRequest = request;
            _client = client;
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
            var resposne = client.Execute<T>(request);
            return new Response<T>(resposne);

        }
    }
}

