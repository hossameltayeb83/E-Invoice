using BlazorProject.Application.Responses;
using BlazorProject.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Common.Mediator.Query
{
	public class GetAllQuery<TEntity, TDto> : IRequest<BaseResponse<List<TDto>>> where TEntity : BaseEntity where TDto : class
	{
		public string filter;
	}
	
}
