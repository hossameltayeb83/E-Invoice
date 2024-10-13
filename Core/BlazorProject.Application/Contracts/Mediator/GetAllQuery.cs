using BlazorProject.Application.Responses;
using BlazorProject.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Contracts.Mediator
{
	public class GetAllQuery<TEntity,TDto> : IRequest<BaseResponse<List<TDto>>> where TEntity : BaseEntity where TDto : class
	{
		public string filter;
	}
	public class GetOneQuery<TEntity, TDto>: IRequest<BaseResponse<TDto>> where TEntity : BaseEntity where TDto : class
	{
		public int Id { get; set; }
	}
	public class CreateCommand<TEntity, TDto> : IRequest<BaseResponse<int>> where TEntity : BaseEntity where TDto: class
	{
		public TDto Dto { get; set; }
	}
	public class UpdateCommand<TEntity, TDto> : IRequest<BaseResponse> where TEntity : BaseEntity where TDto : class
	{
		public TDto Dto { get; set; }
	}
	public class DeleteCommand<TEntity> : IRequest<BaseResponse> where TEntity : BaseEntity
	{
		public int Id { get; set; }
	}
}
