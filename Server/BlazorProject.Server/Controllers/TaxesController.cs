using BlazorProject.Application.Contracts.Mediator;
using BlazorProject.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlazorProject.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TaxesController : BaseController<Tax, TaxDto,TaxWriteDto>
	{
		private readonly IMediator _mediator;
		public TaxesController(IMediator mediator) : base(mediator)
		{
			_mediator = mediator;
		}
	}
}
