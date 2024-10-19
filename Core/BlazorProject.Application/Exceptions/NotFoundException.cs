using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Exceptions
{
	public class NotFoundException : BaseException
	{
        public NotFoundException(string error) : base(error)
		{
			StatusCode = HttpStatusCode.NotFound;
		}
    }
}
