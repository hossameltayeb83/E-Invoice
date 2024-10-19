using BlazorProject.Client.Models;
using BlazorProject.Shared.Dtos;

namespace BlazorProject.Client.Services
{
    public interface ICustomerService
    {
        public Task<List<CustomerDto>> GetList(string name);
    }
}
