using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Shared.Responses
{
	public class BaseResponse
	{
		public bool Success { get; set; } = true;
	}
	public class BaseResponse<T> : BaseResponse
	{
		public T Result { get; set; }
	}
}
