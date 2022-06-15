using eShopSolution.ApiIntegration;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Threading.Tasks;

namespace eShopSolution.WebApp.Controllers.Components
{
    public class SideBarViewComponent : ViewComponent
    {
        private readonly ICategoryApiClient _categoryApiClient;
        public SideBarViewComponent(ICategoryApiClient categoryApiClient)
        {
            _categoryApiClient = categoryApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _categoryApiClient.GetAllCategories(CultureInfo.CurrentCulture.Name);
            return View(items.ResultObj);
        }
    }
}
