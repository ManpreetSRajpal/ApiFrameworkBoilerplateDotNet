using System;
namespace ApiFrameworkCore.APIHealper.APIResponse
{
	public interface IResponse:IRestApiResponse{

        string GetResponseData();
    }

    public interface IResponse<T>:IRestApiResponse
    {
        T GetResponseData();
    }
}

 