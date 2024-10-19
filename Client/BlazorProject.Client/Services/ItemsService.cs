using BlazorProject.Client.Models;
using BlazorProject.Shared.Dtos;
using BlazorProject.Shared.Responses;
using System.Collections.Generic;
using System.Net.Http.Json;

namespace BlazorProject.Client.Services
{
    public class ItemsService :BaseService<ItemDto>
    {
        //private readonly HttpClient _client;
        //private string _url;
        public ItemsService(HttpClient client) : base(client,"Items") { }
        //{
        //    _client = client;
        //    _url = client.BaseAddress.AbsolutePath + "/Items";
        //}
  //      public async Task<(List<ItemDto>? Result,PaginationInfo? Pagination)> GetItems()
  //      {

		//	var response = await _client.GetFromJsonAsync<PaginatedResponse<List<ItemDto>>>(_url);
  //          if (response.Success)
  //          {
  //              var paginaiton = new PaginationInfo { Page = response.Page, PageSize = response.PageSize, TotalCount = response.TotalCount, TotalPages = response.TotalPages, HasNextPage = response.HasNextPage, HasPreviousPage = response.HasPreviousPage };
  //              return (response.Result,paginaiton);
  //          }
  //          else return (null,null);
  //      }
  //      public async Task<(List<ItemDto>? Result, PaginationInfo? Pagination)> GetItems(ItemDto searchCriteria,int page,int pageSize)
		//{
  //          var queryParams= searchCriteria.ToQueryParameters();
		//	var response = await _client.GetFromJsonAsync<PaginatedResponse<List<ItemDto>>>(_url+queryParams+$"&Page={page}&PageSize={pageSize}");
		//	if (response.Success)
		//	{
		//		var paginaiton = new PaginationInfo { Page = response.Page, PageSize = response.PageSize, TotalCount = response.TotalCount, TotalPages = response.TotalPages, HasNextPage = response.HasNextPage, HasPreviousPage = response.HasPreviousPage };
		//		return (response.Result, paginaiton);
		//	}
		//	else return (null, null);
		//}
  //      public async Task<ItemDto> GetItem(int id)
  //      {
  //          var response = await _client.GetFromJsonAsync<BaseResponse<ItemDto>>(_url+$"/{id}");
  //          if (response.Success)
  //          {
  //              return response.Result;
  //          }
  //          else return null;
  //      }
  //      public async Task<int?> AddItem(ItemDto item)
  //      {
  //          var httpResponse = await _client.PostAsJsonAsync(_url,item);
  //          var response = await httpResponse.Content.ReadFromJsonAsync<BaseResponse<int>>();
  //          if (response.Success)
  //          {
  //              return response.Result;
  //          }
  //          else return null;
  //      }
  //      public async Task<bool> UpdateItem(ItemDto item)
  //      {
  //          var httpResponse = await _client.PutAsJsonAsync(_url, item);
  //          var response = await httpResponse.Content.ReadFromJsonAsync<BaseResponse>();
  //          return response.Success;
  //      }
  //      public async Task<bool> DeleteItem(int id)
  //      {
  //          var response = await _client.DeleteFromJsonAsync<BaseResponse>(_url+$"/{id}");
  //          return response.Success;
  //      }
    }
}

