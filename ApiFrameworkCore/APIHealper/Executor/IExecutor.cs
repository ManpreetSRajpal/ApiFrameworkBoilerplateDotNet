using System;
using ApiFrameworkCore.APIHealper.APIResponse;

namespace ApiFrameworkCore.APIHealper.Executor
{
	public interface IExecutor
	{

		IResponse ExecuteRequest();
		IResponse<T> ExecuteRequest<T>();

	}
}

