using AutoMapper;
using BlazorProject.Application.Responses;
using BlazorProject.Domain.Common;
using BlazorProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Contracts.Mediator
{
	internal class GetAllQueryHandler<T,U> : IRequestHandler<GetAllQuery<T,U>, BaseResponse<List<U>>> where T :BaseEntity where U:class
	{
		private readonly IRepository<T> _itemRepository;
		private readonly IMapper _mapper;

		public GetAllQueryHandler(IRepository<T> itemRepository,IMapper mapper)
		{
			_itemRepository = itemRepository;
			_mapper = mapper;
		}
		public async Task<BaseResponse<List<U>>> Handle(GetAllQuery<T,U> request, CancellationToken cancellationToken)
		{
			var response = new BaseResponse<List<U>>();

			var entities = await _itemRepository.ListAllAsync();
			var dtos = _mapper.Map<List<U>>(entities);

			response.Result = dtos;
			return response;
		}
	}
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
			var dto= _mapper.Map<U>(entity);

			response.Result = dto;
			return response;
		}
	}
	internal class DeleteCommandHandler<T> : IRequestHandler<DeleteCommand<T>, BaseResponse> where T : BaseEntity 
	{
		private readonly IRepository<T> _itemRepository;
		private readonly IMapper _mapper;

		public DeleteCommandHandler(IRepository<T> itemRepository, IMapper mapper)
		{
			_itemRepository = itemRepository;
			_mapper = mapper;
		}
		public async Task<BaseResponse> Handle(DeleteCommand<T> request, CancellationToken cancellationToken)
		{
			var response = new BaseResponse();
			var entity = await _itemRepository.GetByIdAsync(request.Id);
			response.Success = await _itemRepository.DeleteAsync(entity);
			return response;
		}
	}
	internal class CreateCommandHandler<T,U> : IRequestHandler<CreateCommand<T,U>, BaseResponse<int>> where T : BaseEntity where U :class
	{
		private readonly IRepository<T> _itemRepository;
		private readonly IMapper _mapper;

		public CreateCommandHandler(IRepository<T> itemRepository, IMapper mapper)
		{
			_itemRepository = itemRepository;
			_mapper = mapper;
		}
		public async Task<BaseResponse<int>> Handle(CreateCommand<T,U> request, CancellationToken cancellationToken)
		{
			var response = new BaseResponse<int>();
			var entity=_mapper.Map<T>(request.Dto);
			response.Result = await _itemRepository.AddAsync(entity);
			return response;
		}
	}
	internal class UpdateCommandHandler<T, U> : IRequestHandler<UpdateCommand<T, U>, BaseResponse> where T : BaseEntity where U : class
	{
		private readonly IRepository<T> _itemRepository;
		private readonly IMapper _mapper;

		public UpdateCommandHandler(IRepository<T> itemRepository, IMapper mapper)
		{
			_itemRepository = itemRepository;
			_mapper = mapper;
		}
		public async Task<BaseResponse> Handle(UpdateCommand<T, U> request, CancellationToken cancellationToken)
		{
			var response = new BaseResponse();
			var entity = _mapper.Map<T>(request.Dto);
			response.Success = await _itemRepository.UpdateAsync(entity);
			return response;
		}
	}
}
