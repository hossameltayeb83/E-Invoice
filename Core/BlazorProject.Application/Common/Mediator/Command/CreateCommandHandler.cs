using AutoMapper;
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

namespace BlazorProject.Application.Common.Mediator.Command
{
	
	internal class CreateCommandHandler<T, U> : IRequestHandler<CreateCommand<T, U>, BaseResponse<int>> where T : BaseEntity where U : class
	{
		private readonly IRepository<T> _repository;
		private readonly IHandlerCustomLogic<T> _handlerLogic;
		private readonly IMapper _mapper;


		public CreateCommandHandler(IRepository<T> repository,IHandlerCustomLogic<T> handlerLogic, IMapper mapper)
		{
			_repository = repository;
			_handlerLogic = handlerLogic;
			_mapper = mapper;
		}
		public CreateCommandHandler(IRepository<T> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		public async Task<BaseResponse<int>> Handle(CreateCommand<T, U> request, CancellationToken cancellationToken)
		{
			var response = new BaseResponse<int>();
			var entity = _mapper.Map<T>(request.Dto);
			if(_handlerLogic is ICustomCreateLogic<T> _handler)
			{
				_handler.CreateLogic(entity);
			}
			response.Result = await _repository.AddAsync(entity);
			return response;
		}
	}
	
}
