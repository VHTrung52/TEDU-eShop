using eShopSolution.AdminApp.Models;
using eShopSolution.AdminApp.Sevices;
using eShopSolution.Utilities.Constants;
using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Controllers.Components
{
    public class NavigationViewComponent : ViewComponent
    {
        private readonly ILanguageApiClient _languageApiClient;

        public NavigationViewComponent(ILanguageApiClient languageApiClient)
        {
            _languageApiClient = languageApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            var response = await _languageApiClient.GetAll();
            var navigationViewModel = new NavigationViewModel()
            {
                CurrentLanguageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId),
                Languages = response.ResultObj
            };

            return View("Default", navigationViewModel);
        }
    }
}