using BlazorProject.Application.Contracts.Mediator;
using BlazorProject.Application.Features.Invoices;
using BlazorProject.Domain.Entities;
using BlazorProject.Shared.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlazorProject.Server.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class InvoicesController : BaseController<Invoice, InvoiceDto>
	{
		private readonly IMediator _mediator;
		public InvoicesController(IMediator mediator) : base(mediator)
		{
			_mediator = mediator;
		}

	}
}