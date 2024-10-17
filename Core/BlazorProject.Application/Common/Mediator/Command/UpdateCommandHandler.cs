using AutoMapper;
using BlazorProject.Application.Contracts;
using BlazorProject.Application.Contracts.Infrastructre;
using BlazorProject.Application.Contracts.Mediator;
using BlazorProject.Shared.Responses;
using BlazorProject.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Common.Mediator.Command
{
	internal class UpdateCommandHandler<T, U> : IRequestHandler<UpdateCommand<T, U>, BaseResponse> where T : BaseEntity where U : class
	{
		private readonly IRepository<T> _repository;
		private readonly IHandlerCustomLogic<T> _handlerLogic;
		private readonly IMapper _mapper;


		public UpdateCommandHandler(IRepository<T> repository, IHandlerCustomLogic<T> handlerLogic, IMapper mapper)
		{
			_repository = repository;
			_handlerLogic = handlerLogic;
			_mapper = mapper;
		}
		public UpdateCommandHandler(IRepository<T> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		public async Task<BaseResponse> Handle(UpdateCommand<T, U> request, CancellationToken cancellationToken)
		{
			var response = new BaseResponse();
			var entity = _mapper.Map<T>(request.Dto);
			if (_handlerLogic is ICustomUpdateLogic<T> _handler)
			{
				_handler.UpdateLogic(entity);
			}
			response.Success = await _repository.UpdateAsync(entity);
			return response;
		}
	}
}
