using eShopSolution.Application.System.Roles;
using eShopSolution.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolesController : BaseController
    {
        private readonly IRoleService _roleService;

        public RolesController(
            ILogger<RolesController> lgr,
            IRoleService roleService)
            : base(lgr)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                var response = await _roleService.GetAllRoles();
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception in BackendApi\\RolesController\\GetAll");
                return ServerError();
            }
        }
    }
}