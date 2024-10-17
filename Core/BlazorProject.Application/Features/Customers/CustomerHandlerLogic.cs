using BlazorProject.Application.Contracts.Infrastructre;
using BlazorProject.Application.Contracts.Mediator;
using BlazorProject.Domain.Entities;
using BlazorProject.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Features.Customers
{
    internal class CustomerHandlerLogic : IHandlerCustomLogic<Customer>, ICustomGetAllLogic<Customer, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerHandlerLogic(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<(IReadOnlyList<Customer>,int)> GetAllLogic(CustomerDto searchCriteria, int page, int pageSize)
        {
            return await _customerRepository.GetCustomers(searchCriteria,page,pageSize);
        }

    }
}
