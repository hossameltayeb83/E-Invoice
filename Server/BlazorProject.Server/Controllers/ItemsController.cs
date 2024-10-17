using BlazorProject.Application.Contracts.Mediator;
using BlazorProject.Application.Features.Items;
using BlazorProject.Domain.Entities;
using BlazorProject.Shared.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorProject.Server.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class ItemsController : BaseController<Item,ItemDto>
	{
		private readonly IMediator _mediator;
		public ItemsController(IMediator mediator) : base(mediator) 
		{
			_mediator = mediator;
		}

	}
}
