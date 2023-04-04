using System;
using System.Net;

namespace ApiFrameworkCore.APIHealper.APIResponse
{
	public interface IRestApiResponse
	{

		HttpStatusCode GethttpStatusCode();
		Exception getException();

	}
}

