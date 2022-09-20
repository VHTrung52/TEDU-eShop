using eShopSolution.Application.Utilities.Slides;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidesController : BaseController
    {
        private readonly ISlideService _slideService;

        public SlidesController(
            ILogger<SlidesController> lgr,
            ISlideService slideService)
            : base(lgr)
        {
            _slideService = slideService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSlide(string languageId)
        {
            try
            {
                var response = await _slideService.GetAllSlide(languageId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception in BackendApi\\SlidesController\\GetAllSlide");
                return ServerError();
            }
        }
    }
}