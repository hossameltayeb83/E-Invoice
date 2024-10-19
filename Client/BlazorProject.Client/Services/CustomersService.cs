using BlazorProject.Shared.Dtos;

namespace BlazorProject.Client.Services
{
    public class CustomersService : BaseService<CustomerDto>
    {
        public CustomersService(HttpClient client) : base(client, "Customers")
        {
        }
    }
}
