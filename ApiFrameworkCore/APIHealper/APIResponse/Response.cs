using System;
using RestSharp;

namespace ApiFrameworkCore.APIHealper.APIResponse
{
	public class Response:AbstractResponse
	{
        private readonly RestResponse _restResponse;

        public Response(RestResponse restResponse):base(restResponse) {
            _restResponse = restResponse;
        }

        public override string GetResponseData()
        {
            return _restResponse.Content;
        }
    }


    public class Response<T> : AbstractResponse<T>
    {
        private readonly RestResponse<T> _restResponse;

        public Response(RestResponse<T> restResponse) : base(restResponse)
        {
            _restResponse = restResponse;
        }

        public override T GetResponseData()
        {
            return _restResponse.Data;
        }
    }
}

