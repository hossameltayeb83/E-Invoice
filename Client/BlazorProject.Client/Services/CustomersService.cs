using BlazorProject.Client.Models;
using BlazorProject.Shared.Dtos;
using BlazorProject.Shared.Responses;
using System.Net.Http.Json;

namespace BlazorProject.Client.Services
{
    public class CustomersService : BaseService<CustomerDto>
    {

        public CustomersService(HttpClient client) : base(client, "Customers")
        {
        }

        //public async Task<List<CustomerDto>> GetList(string name)
        //{
        //    var queryParam = $"?Name={name}";
        //    var response = await _client.GetFromJsonAsync<PaginatedResponse<List<CustomerDto>>>(_url + queryParam);
        //    if (response.Success)
        //    {
        //            return response.Result;
        //    }
        //    return new List<CustomerDto>(); 
        //}
    }
}
