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

        public LanguagesController(ILogger<LanguagesController> lgr, ILanguageService LanguageService) : base(lgr)
        {
            _languageService = LanguageService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _languageService.GetAll();
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