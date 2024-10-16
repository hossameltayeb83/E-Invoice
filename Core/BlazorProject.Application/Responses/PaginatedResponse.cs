using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Responses
{
	internal class PaginatedResponse<T> : BaseResponse<T>
	{
		public int Page { get; }
		public int PageSize { get; }
		public int TotalPages { get; }
		public int TotalCount { get; }

		public bool HasNextPage => (Page * PageSize) < TotalCount;
		public bool HasPreviousPage => Page > 1;
        public PaginatedResponse(int page, int pageSize, int totalCount)
        {
			Page = page;
			PageSize = pageSize;
			TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
			TotalCount = totalCount;
		}
    }
}
