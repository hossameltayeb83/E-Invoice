using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Contracts.Mediator
{
	internal interface ICustomGetOneLogic<T>
	{
		Task<T?> GetOneLogic(int id);
	}
}
