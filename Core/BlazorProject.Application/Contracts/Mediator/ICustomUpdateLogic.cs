﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Contracts.Mediator
{
	internal interface ICustomUpdateLogic<TEntity>
	{
		void UpdateLogic(TEntity entity);
	}
}
