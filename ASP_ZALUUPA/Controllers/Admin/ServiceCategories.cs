using ASP_ZALUUPA.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ASP_ZALUUPA.Controllers.Admin
{
    public partial class AdminController
    {
        public async Task<IActionResult> ServiceCategoriesEdit(int id)
        {
            // в зависимости от наличия id, либо добавляем, либо изменяем запись
            ServiceCategory? entity = id == 0
                ? new ServiceCategory()
                : await _dataManager!.ServiceCategories.GetServiceCategoryByIdAsync(id);
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> ServiceCategoriesEdit(ServiceCategory entity)
        {
            // если в модели есть ошибки, возвращаем на доработку
            if (!ModelState.IsValid)
                return View(entity);

            await _dataManager!.ServiceCategories.SaveServiceCategoryAsync(entity);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ServiceCategoriesDelete(int id)
        {
            // в целях безопасности каскадное удаление отключено,
            // поэтому убедитесь, что с удаляемой категорией нет связанных услуг
            await _dataManager!.ServiceCategories.DeleteServiceCategoryAsync(id);

            return RedirectToAction("Index");
        }
    }
}
