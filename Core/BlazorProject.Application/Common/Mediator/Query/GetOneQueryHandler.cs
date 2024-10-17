using AutoMapper;
using BlazorProject.Application.Common.Mediator.Command;
using BlazorProject.Application.Contracts;
using BlazorProject.Application.Contracts.Mediator;
using BlazorProject.Domain.Common;
using BlazorProject.Shared.Responses;
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
		private readonly IRepository<T> _repository;
		private readonly IHandlerCustomLogic<T> _handlerLogic;
		private readonly IMapper _mapper;

		public GetOneQueryHandler(IRepository<T> repository, IHandlerCustomLogic<T> handlerLogic, IMapper mapper)
		{
			_repository = repository;
			_handlerLogic = handlerLogic;
			_mapper = mapper;
		}
		public GetOneQueryHandler(IRepository<T> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		public async Task<BaseResponse<U>> Handle(GetOneQuery<T, U> request, CancellationToken cancellationToken)
		{
			var response = new BaseResponse<U>();
			T? entity;
			if (_handlerLogic is ICustomGetOneLogic<T> _handler)
			{
				entity = await _handler.GetOneLogic(request.Id);
			}
			else
			{
				entity = await _repository.GetByIdAsync(request.Id);
			}
			if (entity == null)
			{
				response.Success = false;
				return response;
			}
			var dto = _mapper.Map<U>(entity);

			response.Result = dto;
			return response;
		}
	}
	
}
