using System;
using ApiFrameworkCore.Client;
using RestSharp;

namespace ApiFrameworkCore.APIHealper.APIRequest
{
    public class PostRequestBuilder : AbstractRequest
    {

        private readonly RestRequest _restRequest;

        public PostRequestBuilder()
        {
            _restRequest = new RestRequest()
            {
                Method = Method.Post
            };

        }

        public override RestRequest Build()
        {
            return _restRequest;
        }

        // URL

        public PostRequestBuilder WithUrl(string url)
        {
            WithUrl(url, _restRequest);
            return this;

        }

        // Headers

        public PostRequestBuilder withHeader(Dictionary<string, string> headers)
        {
            WithHeader(headers, _restRequest);
            return this;

        }




        // REquest Body

        public PostRequestBuilder WithBody<T>(T body,RequestBodyType requestBodyType) where T : class
        {

            switch (requestBodyType)
            {

                case RequestBodyType.STRING:
                    _restRequest.AddStringBody(body.ToString(),ContentType.Json);
                    break;
                case RequestBodyType.JSON:
                    _restRequest.AddJsonBody<T>(body);
                    break;


            }
            return this;


        }


        public PostRequestBuilder WithQueryParameter(Dictionary<string, string> parameter) {

            WithQueryParameter(parameter, _restRequest);
                

            return this;

        }



        protected override void WithQueryParameter(Dictionary<string, string> queryParams, RestRequest restRequest)
        {
            foreach (string key in queryParams.Keys) {
                restRequest.AddQueryParameter(key, queryParams[key]);

            }
        }

        public enum RequestBodyType{
            STRING,
            JSON
            
        }


    }
}

