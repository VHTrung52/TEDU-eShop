using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.Utilities.Slides;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.ApiIntegration
{
    public interface ISlideApiClient
    {
        Task<List<SlideViewModel>> GetAllSlide();
    }
}