using BlazorProject.Shared.Dtos;

namespace BlazorProject.Client.Services
{
    public class TaxesService : BaseService<TaxDto>
    {
        public TaxesService(HttpClient client) : base(client, "Taxes") { }
        
    }
}
