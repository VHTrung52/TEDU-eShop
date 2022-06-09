using eShopSolution.ViewModels.Utilities.Slides;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.Application.Utilities.Slides
{
    public interface ISlideService
    {
        Task<List<SlideViewModel>> GetAllSlide();
    }
}