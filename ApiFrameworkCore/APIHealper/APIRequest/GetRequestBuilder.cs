using System;
using ApiFrameworkCore.Client;
using RestSharp;

namespace ApiFrameworkCore.APIHealper.APIRequest
{
	public class GetRequestBuilder:AbstractRequest
	{

        private readonly RestRequest _restRequest;

        public GetRequestBuilder()
		{
            _restRequest = new RestRequest()
            {
                Method=Method.Get
            };
		}

        public override RestRequest Build()
        {
            return _restRequest;
        }


        public  GetRequestBuilder WithUrl(string url) {
            WithUrl(url, _restRequest);
            return this;

        }

        public GetRequestBuilder WithHeader(Dictionary<string, string> header) {
            WithHeader(header,_restRequest);
            return this;
        }

        public GetRequestBuilder WithQueryParameter(Dictionary<string, string> parameter) {

            WithQueryParameter(parameter, _restRequest);
            return this;
        }

    }
}

