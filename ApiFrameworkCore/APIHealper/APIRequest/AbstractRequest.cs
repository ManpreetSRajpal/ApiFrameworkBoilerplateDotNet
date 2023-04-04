using System;
using RestSharp;

namespace ApiFrameworkCore.Client
{
	public abstract class AbstractRequest
	{
		public abstract RestRequest Build();

		protected virtual void WithUrl(string url, RestRequest restRequest) {

			restRequest.Resource = url;

		}

		protected virtual void WithHeader(Dictionary<string, string> header, RestRequest restRequest) {

			foreach(string key in header.Keys){
				restRequest.AddOrUpdateHeader(key, header[key]);
			}
		}


		protected virtual void WithQueryParameter(Dictionary<string, string> queryParams,RestRequest restRequest) {
			foreach (string key in queryParams.Keys) {
				restRequest.AddParameter(key, queryParams[key]);
			}
		}
	}
}

