using ASP_ZALUUPA.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP_ZALUUPA.Controllers.Admin
{
    [Authorize(Roles = "admin")]
    public partial class AdminController : Controller
    {
        private readonly DataManager? _dataManager;

        public AdminController(DataManager? dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<ActionResult> Index()
        {
            if (_dataManager != null)
            {
                ViewBag.ServiceCategories = await _dataManager.ServiceCategories.GetServiceCategoriesAsync();
                ViewBag.Services = await _dataManager.Services.GetServicesAsync();
                return View();
            }
            return View();
        }
    }
}
