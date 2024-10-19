using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Exceptions
{
	public class BaseException : Exception
	{
		public HttpStatusCode StatusCode { get; protected set; }
		public string Msg { get; protected set; }
		public BaseException(string error) { Msg = error; }
		public BaseException() { }
	}
}
