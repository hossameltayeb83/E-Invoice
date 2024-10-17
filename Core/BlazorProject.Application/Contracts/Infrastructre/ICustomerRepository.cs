using BlazorProject.Application.Features.Customers;
using BlazorProject.Domain.Entities;
using BlazorProject.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Contracts.Infrastructre
{
	public interface ICustomerRepository
	{
		Task<(IReadOnlyList<Customer>, int)> GetCustomers(CustomerDto searchCriteria, int page, int pageSize);
	}
}
