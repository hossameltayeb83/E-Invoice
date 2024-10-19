using BlazorProject.Shared.Dtos;

namespace BlazorProject.Client.Services
{
    public class InvoicesService : BaseService<InvoiceDto>
    {
        public InvoicesService(HttpClient client) : base(client, "Invoices")
        {
        }
    }
}
