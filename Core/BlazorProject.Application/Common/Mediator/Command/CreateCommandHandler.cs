using AutoMapper;
using BlazorProject.Application.Contracts;
using BlazorProject.Application.Contracts.Mediator;
using BlazorProject.Application.Exceptions;
using BlazorProject.Shared.Responses;
using BlazorProject.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace BlazorProject.Application.Common.Mediator.Command
{
	
	internal class CreateCommandHandler<T, U> : IRequestHandler<CreateCommand<T, U>, BaseResponse<int>> where T : BaseEntity where U : class
	{
		private readonly IRepository<T> _repository;
		private readonly IHandlerCustomLogic<T> _handlerLogic;
		private readonly AbstractValidator<U> _validator;
		private readonly IMapper _mapper;


		public CreateCommandHandler(IRepository<T> repository,IHandlerCustomLogic<T> handlerLogic,AbstractValidator<U> validator,IMapper mapper)
		{
			_repository = repository;
			_handlerLogic = handlerLogic;
			_validator= validator;
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
			var validationResult = _validator.Validate(request.Dto);
			if (!validationResult.IsValid)
				throw new CustomValidationException(validationResult);
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
