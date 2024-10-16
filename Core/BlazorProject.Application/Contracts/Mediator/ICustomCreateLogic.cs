using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Contracts.Mediator
{
	internal interface ICustomCreateLogic<TEntity>
	{
		void CreateLogic(TEntity entity);
	}
}
