using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eShopSolution.WebApp.Controllers.Components
{
    public class CarouselViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
