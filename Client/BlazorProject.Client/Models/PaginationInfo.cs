using BlazorProject.Shared.Responses;

namespace BlazorProject.Client.Models
{
	public class PaginationInfo
	{
        
        public int Page { get; set; }
		public int PageSize { get; set; }
		public int TotalPages { get; set; }
		public int TotalCount { get; set; }
		public bool HasNextPage { get; set; }
		public bool HasPreviousPage { get; set; }
	}
}
