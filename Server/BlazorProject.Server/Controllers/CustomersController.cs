﻿using BlazorProject.Application.Contracts.Mediator;
using BlazorProject.Application.Features.Customers;
using BlazorProject.Domain.Entities;
using BlazorProject.Shared.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlazorProject.Server.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class CustomersController : BaseController<Customer, CustomerDto>
	{
		private readonly IMediator _mediator;
		public CustomersController(IMediator mediator) : base(mediator)
		{
			_mediator = mediator;
		}

	}
}
