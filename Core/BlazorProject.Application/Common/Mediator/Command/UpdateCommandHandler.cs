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
