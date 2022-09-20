using eShopSolution.Application.Common;
using eShopSolution.Data.EF;
using eShopSolution.Data.Enums;
using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.Utilities.Slides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.Application.Utilities.Slides
{
    public class SlideService : BaseService, ISlideService
    {
        private readonly IStorageService _storageService;
        public SlideService(ILogger<SlideService> lgr, EShopDbContext context, IStorageService storageService) : base(lgr, context)
        {
            _storageService = storageService;
        }

        public async Task<List<SlideViewModel>> GetAllSlide(string languageId)
        {
            var query = (
                from slide in DbContext.Slides
                join slideTranslation in DbContext.SlideTranslations
                    on slide.Id equals slideTranslation.SlideId
                where
                    (slideTranslation.LanguageId == languageId)
                    && slide.Status == Status.Active
                select new
                {
                    slide,
                    slideTranslation,
                })
                .OrderBy(x => x.slide.SortOrder);

            var result = await query
                .Select(x => new SlideViewModel()
                {
                    Id = x.slide.Id,
                    Name = x.slideTranslation.Name,
                    Description = x.slideTranslation.Description,
                    Url = x.slideTranslation.Url,
                    ImagePath = _storageService.GetCarouselImageFileUrl(x.slideTranslation.ImagePath)
                })
                .ToListAsync();

            return result;
        }
    }
}