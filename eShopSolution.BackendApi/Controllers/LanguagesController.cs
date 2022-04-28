using eShopSolution.Application.System.Languages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LanguagesController : BaseController
    {
        private readonly ILanguageService _languageService;

        public LanguagesController(
            ILogger<LanguagesController> lgr,
            ILanguageService languageService)
            : base(lgr)
        {
            _languageService = languageService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllLanguages()
        {
            try
            {
                var response = await _languageService.GetAllLanguages();
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception in BackendApi\\LanguagesController\\GetAll");
                return ServerError();
            }
        }
    }
}