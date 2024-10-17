using AutoMapper;
using BlazorProject.Application.Common.Mediator.Command;
using BlazorProject.Application.Contracts;
using BlazorProject.Application.Contracts.Mediator;
using BlazorProject.Shared.Responses;
using BlazorProject.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Common.Mediator.Query
{
	internal class GetAllQueryHandler<T, U> : IRequestHandler<GetAllQuery<T, U>, BaseResponse<List<U>>> where T : BaseEntity where U : class
	{
		private readonly IRepository<T> _repository;
		private readonly IHandlerCustomLogic<T> _handlerLogic;

		private readonly IMapper _mapper;
		public GetAllQueryHandler(IRepository<T> repository, IHandlerCustomLogic<T> handlerLogic, IMapper mapper)
		{
			_repository = repository;
			_handlerLogic = handlerLogic;
			_mapper = mapper;
		}
		public GetAllQueryHandler(IRepository<T> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		public async Task<BaseResponse<List<U>>> Handle(GetAllQuery<T, U> request, CancellationToken cancellationToken)
		{
			(IReadOnlyList<T> Entities, int Count) result;
			if (_handlerLogic is ICustomGetAllLogic<T,U> _handler && request.SerachCriteria!=null)
			{
				result=await _handler.GetAllLogic(request.SerachCriteria,request.Page,request.PageSize);
			}
			else
			{
				result = await _repository.GetAllAsync(request.Page, request.PageSize);
			}
			var dtos = _mapper.Map<List<U>>(result.Entities);

			BaseResponse<List<U>> response = new PaginatedResponse<List<U>>(request.Page,request.PageSize,result.Count);
			response.Result = dtos;
			return response;
		}
	}
	
}
