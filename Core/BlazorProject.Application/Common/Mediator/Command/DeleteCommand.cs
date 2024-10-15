using BlazorProject.Application.Responses;
using BlazorProject.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Common.Mediator.Command
{
	
	public class DeleteCommand<TEntity,TDto> : IRequest<BaseResponse> where TEntity : BaseEntity where TDto : class
	{
		public int Id { get; set; }
	}
}
