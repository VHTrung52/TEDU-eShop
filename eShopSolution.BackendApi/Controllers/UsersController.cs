using eShopSolution.Application.System.Users;
using eShopSolution.ViewModels.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        public UsersController(IUserService userService, ILogger<UsersController> lgr) : base(lgr)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _userService.Authenticate(request);

            if (string.IsNullOrEmpty(response.ResultObj))
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _userService.Register(request);
            if (!response.IsSuccessed)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        //http:/localhost/api/users/id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _userService.UpdateUser(id, request);

            if (!response.IsSuccessed)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("{id}/roles")]
        public async Task<IActionResult> RoleAssign(Guid id, [FromBody] RoleAssignRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _userService.RoleAssign(id, request);

            if (!response.IsSuccessed)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        //http://localhost/api/users/paging?pageIndex=1&pageSize=10&keyword=
        [HttpGet("paging")]
        public async Task<IActionResult> GetUserPaging([FromQuery] GetUserPagingRequest request)
        {
            var response = await _userService.GetUserPaging(request);
            return Ok(response);
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
                Logger.LogError(ex, "Exception in GetUserById for {id}", id);
                return ServerError();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var response = await _userService.DeleteUser(id);
            return Ok(response);
        }
    }
}