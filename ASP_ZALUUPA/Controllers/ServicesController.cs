using ASP_ZALUUPA.Domain;
using ASP_ZALUUPA.Domain.Entities;
using ASP_ZALUUPA.infrastructure;
using ASP_ZALUUPA.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_ZALUUPA.Controllers
{
    public class ServicesController : Controller
    {
        private readonly DataManager _dataManager;

        public ServicesController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Service> list = await _dataManager.Services.GetServicesAsync();

            // оборот в DTO
            IEnumerable<ServiceDTO> listDTO = HelperDTO.TransformServices(list);

            return View(listDTO);
        }

        public async Task<IActionResult> Show(int id)
        {
            Service? entity = await _dataManager.Services.GetServiceByIdAsync(id);

            if (entity is null)
                return NotFound();

            ServiceDTO entityDTO = HelperDTO.TransformService(entity);
            return View(entityDTO);
        }
    }
}
