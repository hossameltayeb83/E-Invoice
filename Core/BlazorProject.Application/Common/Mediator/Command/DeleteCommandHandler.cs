using AutoMapper;
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
}
