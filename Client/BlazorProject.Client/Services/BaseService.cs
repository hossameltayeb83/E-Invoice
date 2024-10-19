using BlazorProject.Client.Models;
using BlazorProject.Shared.Dtos;
using BlazorProject.Shared.Responses;
using System.Net.Http.Json;

namespace BlazorProject.Client.Services
{
    public class BaseService<TDto> :IService<TDto> where TDto : class, IDto 
    {
        protected readonly HttpClient _client;
        protected string _url;
        public BaseService(HttpClient client,string resource)
        {
            _client = client;
            _url = client.BaseAddress.AbsolutePath + $"/{resource}";
        }
        public async Task<(List<TDto>? Result, PaginationInfo? Pagination)> GetAll()
        {

            var response = await _client.GetFromJsonAsync<PaginatedResponse<List<TDto>>>(_url);
            if (response.Success)
            {
                var paginaiton = new PaginationInfo { Page = response.Page, PageSize = response.PageSize, TotalCount = response.TotalCount, TotalPages = response.TotalPages, HasNextPage = response.HasNextPage, HasPreviousPage = response.HasPreviousPage };
                return (response.Result, paginaiton);
            }
            else return (null, null);
        }
        public async Task<(List<TDto>? Result, PaginationInfo? Pagination)> GetAllWithSearch(TDto searchCriteria, int page, int pageSize)
        {
            var queryParams = searchCriteria.ToQueryParameters();
            var response = await _client.GetFromJsonAsync<PaginatedResponse<List<TDto>>>(_url + queryParams + $"&Page={page}&PageSize={pageSize}");
            if (response.Success)
            {
                var paginaiton = new PaginationInfo { Page = response.Page, PageSize = response.PageSize, TotalCount = response.TotalCount, TotalPages = response.TotalPages, HasNextPage = response.HasNextPage, HasPreviousPage = response.HasPreviousPage };
                return (response.Result, paginaiton);
            }
            else return (null, null);
        }
        public async Task<TDto> GetOne(int id)
        {
            var response = await _client.GetFromJsonAsync<BaseResponse<TDto>>(_url + $"/{id}");
            if (response.Success)
            {
                return response.Result;
            }
            else return null;
        }
        public async Task<int?> Create(TDto item)
        {
            var httpResponse = await _client.PostAsJsonAsync(_url, item);
            var response = await httpResponse.Content.ReadFromJsonAsync<BaseResponse<int>>();
            if (response.Success)
            {
                return response.Result;
            }
            else return null;
        }
        public async Task<bool> Update(TDto item)
        {
            var httpResponse = await _client.PutAsJsonAsync(_url, item);
            var response = await httpResponse.Content.ReadFromJsonAsync<BaseResponse>();
            return response.Success;
        }
        public async Task<bool> Delete(int id)
        {
            var response = await _client.DeleteFromJsonAsync<BaseResponse>(_url + $"/{id}");
            return response.Success;
        }

        public async Task<List<TDto>?> GetList(string column, string value)
        {
            
            var queryParam = $"?{column}={value}";
            var response = await _client.GetFromJsonAsync<PaginatedResponse<List<TDto>>>(_url + queryParam);
            if (response.Success)
            {
                return response.Result;
            }
            return null;
            
        }
    }
}
