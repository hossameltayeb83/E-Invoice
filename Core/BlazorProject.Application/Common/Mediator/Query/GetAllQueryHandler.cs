using AutoMapper;
using BlazorProject.Application.Common.Mediator.Command;
using BlazorProject.Application.Contracts;
using BlazorProject.Application.Contracts.Mediator;
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
	internal class GetAllQueryHandler<T, U> : IRequestHandler<GetAllQuery<T, U>, BaseResponse<List<U>>> where T : BaseEntity where U : class
	{
		private readonly IRepository<T> _itemRepository;
		private readonly IHandlerCustomLogic<T> _HandlerLogic;

		private readonly IMapper _mapper;
		public GetAllQueryHandler(IRepository<T> itemRepository, IHandlerCustomLogic<T> HandlerLogic, IMapper mapper)
		{
			_itemRepository = itemRepository;
			_HandlerLogic = HandlerLogic;
			_mapper = mapper;
		}
		public GetAllQueryHandler(IRepository<T> itemRepository, IMapper mapper)
		{
			_itemRepository = itemRepository;
			_mapper = mapper;
		}
		public async Task<BaseResponse<List<U>>> Handle(GetAllQuery<T, U> request, CancellationToken cancellationToken)
		{
			BaseResponse<List<U>> response = new PaginatedResponse<List<U>>(request.PageSize,request.PageCount,10);
			IReadOnlyList<T> entities;
			if (_HandlerLogic is ICustomGetAllLogic<T,U> handler)
			{
				entities=await handler.GetAllLogic(request.SerachCriteria);
			}
			else
			{
				entities = await _itemRepository.ListAllAsync();
			}
			var dtos = _mapper.Map<List<U>>(entities);

			response.Result = dtos;
			return response;
		}
	}
	
}
