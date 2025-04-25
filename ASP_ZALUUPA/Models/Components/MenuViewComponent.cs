using ASP_ZALUUPA.Domain;
using ASP_ZALUUPA.Domain.Entities;
using ASP_ZALUUPA.infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ASP_ZALUUPA.Models.Components
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly DataManager _dataManager;

        public MenuViewComponent(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<Service> list = await _dataManager.Services.GetServicesAsync();

            // оборот в DTO
            IEnumerable<ServiceDTO> listDTO = HelperDTO.TransformServices(list);

            return await Task.FromResult((IViewComponentResult) View("Default", listDTO));
        }
    }
}
