using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Contracts.Mediator
{
	internal interface ICustomGetAllLogic<TEntity,TDto>
	{
		Task<(IReadOnlyList<TEntity> Entities,int Count)> GetAllLogic(TDto searchCriteria, int page, int pageSize);
	}
}
