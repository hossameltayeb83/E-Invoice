using BlazorProject.Application.Contracts.Infrastructre;
using BlazorProject.Application.Contracts.Mediator;
using BlazorProject.Domain.Entities;
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
        public async Task<IReadOnlyList<Customer>> GetAllLogic(CustomerDto searchCriteria)
        {
            return await _customerRepository.GetCustomers(searchCriteria);
        }

    }
}
