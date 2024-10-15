using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Contracts.Mediator
{
	internal interface IHandlerCustomLogic<T>
	{
		void GetAllLogic(T entity);
		Task<T?> GetOneLogic(int id);
		void CreateLogic(T entity);
		void UpdateLogic(T entity);
		void DelteLogic(T entity);
	}
}
