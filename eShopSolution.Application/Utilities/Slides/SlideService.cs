using eShopSolution.Application.Common;
using eShopSolution.Data.EF;
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
        public SlideService(ILogger<SlideService> lgr, EShopDbContext context) : base(lgr, context)
        {
        }

        public async Task<List<SlideViewModel>> GetAllSlide()
        {
            var result = await DbContext.Slides
                .OrderBy(x => x.SortOrder)
                .Select(x => new SlideViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Url = x.Url,
                    ImagePath = x.ImagePath
                })
                .ToListAsync();

            return result;
        }
    }
}