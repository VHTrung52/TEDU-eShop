using eShopSolution.Application.System.Users;
using eShopSolution.ViewModels.System.Users;
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
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(
            ILogger<UsersController> lgr,
            IUserService userService)
            : base(lgr)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _userService.Authenticate(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in BackendApi\\UsersController\\Authenticate");
                return ServerError();
            }
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _userService.Register(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception in BackendApi\\UsersController\\Register for UserName: {request.UserName}");
                return ServerError();
            }
        }

        //http:/localhost/api/users/id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserUpdateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _userService.UpdateUser(id, request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception in BackendApi\\UsersController\\UpdateUser for userId: {id}");
                return ServerError();
            }
        }

        [HttpPut("{id}/roles")]
        public async Task<IActionResult> RoleAssign(Guid id, [FromBody] RoleAssignRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _userService.RoleAssign(id, request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception in BackendApi\\UsersController\\RoleAssign for userId: {id}");
                return ServerError();
            }
        }

        //http://localhost/api/users/paging?pageIndex=1&pageSize=10&keyword=
        [HttpGet("paging")]
        public async Task<IActionResult> GetUserPaging([FromQuery] GetUserPagingRequest request)
        {
            try
            {
                var response = await _userService.GetUserPaging(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in BackendApi\\UsersController\\GetUserPaging");
                return ServerError();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try
            {
                var response = await _userService.GetUserById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception in BackendApi\\UsersController\\GetUserById for userId: {id}");
                return ServerError();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                var response = await _userService.DeleteUser(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception in BackendApi\\UsersController\\DeleteUser for userId: {id}");
                return ServerError();
            }
        }
    }
}