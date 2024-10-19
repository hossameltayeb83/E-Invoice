using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorProject.Application.Exceptions
{
	public class CustomValidationException : BaseException
	{
		public CustomValidationException(ValidationResult error)
		{
			StatusCode = HttpStatusCode.BadRequest;
			List<string> errors = new();
			foreach (var item in error.Errors) { errors.Add(item.ErrorMessage); }
			Msg =JsonSerializer.Serialize(new { errors = errors });
		}
	}
}
