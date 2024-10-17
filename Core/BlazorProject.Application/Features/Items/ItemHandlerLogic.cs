using BlazorProject.Application.Contracts.Infrastructre;
using BlazorProject.Application.Contracts.Mediator;
using BlazorProject.Domain.Entities;
using BlazorProject.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Features.Items
{
    internal class ItemHandlerLogic : IHandlerCustomLogic<Item>, ICustomGetAllLogic<Item, ItemDto>
    {
        private readonly IItemRepository _itemRepository;
        public ItemHandlerLogic(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task<(IReadOnlyList<Item>,int)> GetAllLogic(ItemDto searchCriteria, int page, int pageSize)
        {
            return await _itemRepository.GetItems(searchCriteria, page, pageSize);
        }
    }
}
