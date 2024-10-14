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
	internal class GetOneQueryHandler<T, U> : IRequestHandler<GetOneQuery<T, U>, BaseResponse<U>> where T : BaseEntity where U : class
	{
		private readonly IRepository<T> _itemRepository;
		private readonly IMapper _mapper;

		public GetOneQueryHandler(IRepository<T> itemRepository, IMapper mapper)
		{
			_itemRepository = itemRepository;
			_mapper = mapper;
		}
		public async Task<BaseResponse<U>> Handle(GetOneQuery<T, U> request, CancellationToken cancellationToken)
		{
			var response = new BaseResponse<U>();

			var entity = await _itemRepository.GetByIdAsync(request.Id);
			var dto = _mapper.Map<U>(entity);

			response.Result = dto;
			return response;
		}
	}
	
}
