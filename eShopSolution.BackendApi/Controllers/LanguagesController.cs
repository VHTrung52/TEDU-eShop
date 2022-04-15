using eShopSolution.Application.System.Languages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguagesController(ILanguageService LanguageService)
        {
            _languageService = LanguageService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var result = await _languageService.GetAll();
            return Ok(result);
        }
    }
}