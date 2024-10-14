using AutoMapper;
using BlazorProject.Application.Common.Mediator.Command;
using BlazorProject.Application.Contracts;
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
		private readonly IMapper _mapper;

		public GetAllQueryHandler(IRepository<T> itemRepository, IMapper mapper)
		{
			_itemRepository = itemRepository;
			_mapper = mapper;
		}
		public async Task<BaseResponse<List<U>>> Handle(GetAllQuery<T, U> request, CancellationToken cancellationToken)
		{
			var response = new BaseResponse<List<U>>();

			var entities = await _itemRepository.ListAllAsync();
			var dtos = _mapper.Map<List<U>>(entities);

			response.Result = dtos;
			return response;
		}
	}
	
}
