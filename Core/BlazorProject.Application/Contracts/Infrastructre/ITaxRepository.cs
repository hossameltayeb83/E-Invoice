using BlazorProject.Application.Features.Items;
using BlazorProject.Application.Features.Taxes;
using BlazorProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Contracts.Infrastructre
{
	public interface ITaxRepository
	{
		Task<IReadOnlyList<Tax>> GetTaxes(TaxDto searchCriteria);
	}
}
