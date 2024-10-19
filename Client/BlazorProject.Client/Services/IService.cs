using BlazorProject.Client.Models;
using BlazorProject.Shared.Dtos;

namespace BlazorProject.Client.Services
{
    public interface IService<TDto>
    {
        public Task<(List<TDto>? Result, PaginationInfo? Pagination)> GetAll();
        public Task<(List<TDto>? Result, PaginationInfo? Pagination)> GetAllWithSearch(TDto searchCriteria, int page, int pageSize);
        public Task<TDto> GetOne(int id);
        public Task<int?> Create(TDto item);
        public Task<bool> Update(TDto item);
        public Task<bool> Delete(int id);
    }
}
