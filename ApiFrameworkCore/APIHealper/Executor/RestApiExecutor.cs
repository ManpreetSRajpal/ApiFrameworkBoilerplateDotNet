using System;
using ApiFrameworkCore.APIHealper.APIResponse;

namespace ApiFrameworkCore.APIHealper.Executor
{
	public class RestApiExecutor
	{
		private IExecutor executor;

		public void setExecutor(IExecutor _executor) {

			executor = _executor;

		}

		public IResponse ExecuteRequest() {

			return executor.ExecuteRequest();
		}


        public IResponse<T> ExecuteRequest<T>()
        {

            return executor.ExecuteRequest<T>();
        }

    }
}

