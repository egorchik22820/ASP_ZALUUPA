using ASP_ZALUUPA.Domain.Entities;

namespace ASP_ZALUUPA.Domain.Repositories.Abstract
{
    public interface IServiceCategoriesRepository
    {
        Task<IEnumerable<ServiceCategory>> GetServiceCategoriesAsync();

        Task<ServiceCategory?> GetServiceCategoryByIdAsync(int id);

        Task SaveServiceCategoryAsync(ServiceCategory entity);

        Task DeleteServiceCategoryAsync(int id);
    }
}
