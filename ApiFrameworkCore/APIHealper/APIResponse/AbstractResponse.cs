using System;
using System.Net;
using RestSharp;

namespace ApiFrameworkCore.APIHealper.APIResponse
{
    public abstract class AbstractResponse : IResponse
    {

        private readonly RestResponse _restResponse;

        public AbstractResponse(RestResponse restResponse) {
            _restResponse = restResponse;
        }

        public Exception getException()
        {
            return _restResponse.ErrorException;
        }

        public HttpStatusCode GethttpStatusCode()
        {
            return _restResponse.StatusCode;
        }

        public abstract string GetResponseData();
        
    }

    public abstract class AbstractResponse<T> : IResponse<T>


    {

        private readonly RestResponse<T> _restResponse;

        public AbstractResponse(RestResponse<T> restResponse)
        {
            _restResponse = restResponse;
        }



        public Exception getException()
        {
            throw new NotImplementedException();
        }

        public HttpStatusCode GethttpStatusCode()
        {
            throw new NotImplementedException();
        }

        public abstract T GetResponseData();
        
    }


}

