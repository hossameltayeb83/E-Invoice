using BlazorProject.Application.Contracts.Mediator;
using BlazorProject.Application.Features.Invoices.Command;
using BlazorProject.Application.Features.Invoices.Query;
using BlazorProject.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlazorProject.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class InvoicesController : BaseController<Invoice, InvoiceDto, InvoiceWriteDto>
	{
		private readonly IMediator _mediator;
		public InvoicesController(IMediator mediator) : base(mediator)
		{
			_mediator = mediator;
		}

	}
}