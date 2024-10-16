using BlazorProject.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using BlazorProject.Application.Contracts.Mediator;
using BlazorProject.Domain.Common;
using BlazorProject.Application.Common.Mediator.Command;
using BlazorProject.Application.Common.Mediator.Query;
namespace BlazorProject.Server.Controllers
{

	public abstract class BaseController<TEntity,TDto> :ControllerBase where TEntity : BaseEntity where TDto:class
	{
		private readonly IMediator _mediator;
		protected BaseController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] TDto Dto,int pageCount=1,int pageSize=10)
		{
			var result= await _mediator.Send(new GetAllQuery<TEntity, TDto>() { SerachCriteria=Dto,PageCount=pageCount,PageSize=10});
			return Ok(result);
		}

		// GET api/<ItemController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var result = await _mediator.Send(new GetOneQuery<TEntity, TDto>() { Id=id});
			return Ok(result);
		}

		// POST api/<ItemController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] TDto Dto)
		{
			var result = await _mediator.Send(new CreateCommand<TEntity, TDto>() { Dto=Dto });
			return Ok(result);
		}

		// PUT api/<ItemController>/5
		[HttpPut]
		public async Task<IActionResult> Put([FromBody] TDto Dto)
		{
			var result = await _mediator.Send(new UpdateCommand<TEntity, TDto>() { Dto = Dto });
			return Ok(result);
		}

		// DELETE api/<ItemController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _mediator.Send(new DeleteCommand<TEntity,TDto>() { Id = id });
			return Ok(result);
		}
	}
}
