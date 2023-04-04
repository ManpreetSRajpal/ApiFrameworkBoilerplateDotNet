using System;
using ApiFrameworkCore.Client;
using RestSharp;

namespace ApiFrameworkCore.Client
{
	public class Client : IClient
	{

        private RestClient _client;
        private RestClientOptions _restClientOptions;

        public Client()
		{

            _restClientOptions = new RestClientOptions();
        }

        public void Dispose()
        {
            _client?.Dispose();
        }

        public RestClient GetClient()
        {
            _restClientOptions.ThrowOnDeserializationError = true;
            _client = new RestClient();
            return _client;
        }
    }
}




