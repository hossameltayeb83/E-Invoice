﻿using AutoMapper;
using BlazorProject.Application.Contracts;
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
	
	internal class CreateCommandHandler<T, U> : IRequestHandler<CreateCommand<T, U>, BaseResponse<int>> where T : BaseEntity where U : class
	{
		private readonly IRepository<T> _itemRepository;
		private readonly IMapper _mapper;

		public CreateCommandHandler(IRepository<T> itemRepository, IMapper mapper)
		{
			_itemRepository = itemRepository;
			_mapper = mapper;
		}
		public async Task<BaseResponse<int>> Handle(CreateCommand<T, U> request, CancellationToken cancellationToken)
		{
			var response = new BaseResponse<int>();
			var entity = _mapper.Map<T>(request.Dto);
			response.Result = await _itemRepository.AddAsync(entity);
			return response;
		}
	}
	
}
