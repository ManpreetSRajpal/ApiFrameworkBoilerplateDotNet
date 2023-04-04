using System;
using RestSharp;

namespace ApiFrameworkCore.Client
{
	public interface IClient:IDisposable
	{
		RestClient GetClient();
	}
}

