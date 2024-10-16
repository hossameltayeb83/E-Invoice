using BlazorProject.Application.Features.Customers;
using BlazorProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Contracts.Infrastructre
{
	public interface ICustomerRepository
	{
		Task<IReadOnlyList<Customer>> GetCustomers(CustomerDto searchCriteria);
	}
}
