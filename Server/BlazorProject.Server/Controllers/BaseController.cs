using BlazorProject.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using BlazorProject.Application.Contracts.Mediator;
using BlazorProject.Domain.Common;
namespace BlazorProject.Server.Controllers
{

	public abstract class BaseController<TEntity,TDto,TWriteDto> :ControllerBase where TEntity : BaseEntity where TDto:class where TWriteDto : class
	{
		private readonly IMediator _mediator;
		protected BaseController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var result= await _mediator.Send(new GetAllQuery<TEntity, TDto>());
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
		public async Task<IActionResult> Post([FromBody] TWriteDto Dto)
		{
			var result = await _mediator.Send(new CreateCommand<TEntity, TWriteDto>() { Dto=Dto });
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
			var result = await _mediator.Send(new DeleteCommand<TEntity>() { Id = id });
			return Ok(result);
		}
	}
}
