using BlazorProject.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace BlazorProject.Server.Middlewares
{
	public class ExceptionHandlerMiddleware
	{
		private readonly RequestDelegate _next;

		public ExceptionHandlerMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext httpContext)
		{
			try
			{
				await _next(httpContext);
			}
			catch(Exception ex)
			{
				await HandleException(httpContext, ex);
			}

		}

		private Task HandleException(HttpContext httpContext, Exception exception)
		{
			HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
			httpContext.Response.ContentType = "application/json";
			string result = string.Empty;

			switch (exception)
			{
				case BaseException baseException:
					statusCode = baseException.StatusCode;
					result = baseException.Msg;
					break;
			}

			httpContext.Response.StatusCode = (int)statusCode;

			if (result == string.Empty)
			{
				result = JsonSerializer.Serialize(new { errors = new List<string> { exception.Message } });
			}
			return httpContext.Response.WriteAsync(result);
		}
	}
	public static class ExceptionHandlerMiddlewareExtensions
	{
		public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder app)
		{
			return app.UseMiddleware<ExceptionHandlerMiddleware>();
		}
	}

}
