using BlazorProject.Application.Contracts.Infrastructre;
using BlazorProject.Application.Contracts.Mediator;
using BlazorProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Features.Taxes
{
    internal class TaxHandlerLogic : IHandlerCustomLogic<Tax>, ICustomGetAllLogic<Tax, TaxDto>
    {
        private readonly ITaxRepository _taxRepository;
        public TaxHandlerLogic(ITaxRepository taxRepository)
        {
            _taxRepository = taxRepository;
        }

        public async Task<IReadOnlyList<Tax>> GetAllLogic(TaxDto searchCriteria)
        {
            return await _taxRepository.GetTaxes(searchCriteria);
        }
    }
}
