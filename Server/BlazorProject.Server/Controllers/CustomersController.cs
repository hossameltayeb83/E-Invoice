using BlazorProject.Application.Contracts.Mediator;
using BlazorProject.Application.Features.Customers.Command;
using BlazorProject.Application.Features.Customers.Query;
using BlazorProject.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlazorProject.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomersController : BaseController<Customer, CustomerDto, CustomerWriteDto>
	{
		private readonly IMediator _mediator;
		public CustomersController(IMediator mediator) : base(mediator)
		{
			_mediator = mediator;
		}

	}
}
