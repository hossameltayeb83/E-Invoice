using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Domain.Common
{
	public abstract class AuditableEntity : BaseEntity
	{
		public DateTime DateTimeIssued { get; set; }
	}
}
