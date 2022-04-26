using eShopSolution.AdminApp.Sevices;
using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.System.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IConfiguration _configuration;
        private readonly IRoleApiClient _roleApiClient;

        public UserController(
            ILogger<UserController> lgr,
            IUserApiClient userApiClient,
            IConfiguration configuration,
            IRoleApiClient roleApiClient)
            : base(lgr)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
            _roleApiClient = roleApiClient;
        }

        public async Task<IActionResult> Index(string keyWord, int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetUserPagingRequest()
            {
                Keyword = keyWord,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            var response = await _userApiClient.GetUsersPagings(request);
            ViewBag.KeyWord = keyWord;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }

            return View(response.ResultObj);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var response = await _userApiClient.GetUserById(id);
            return View(response.ResultObj);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var response = await _userApiClient.RegiterUser(request);
            if (!response.IsSuccessed)
            {
                ModelState.AddModelError("", response.Message);
                return View(request);
            }

            TempData["result"] = response.Message;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _userApiClient.GetUserById(id);
            if (!response.IsSuccessed)
            {
                return RedirectToAction("Error", "Home");
            }

            var user = response.ResultObj;
            var userUpdateRequest = new UserUpdateRequest()
            {
                Dob = user.Dob,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Id = id
            };

            return View(userUpdateRequest);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var response = await _userApiClient.UpdateUser(request.Id, request);
            if (!response.IsSuccessed)
            {
                ModelState.AddModelError("", response.Message);
                return View(response);
            }

            TempData["result"] = response.Message;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("Token");
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            return View(new UserDeleteRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UserDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var response = await _userApiClient.DeleteUser(request.Id);
            if (!response.IsSuccessed)
            {
                ModelState.AddModelError("", response.Message);
                return View(request);
            }

            TempData["result"] = response.Message;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> RoleAssign(Guid id)
        {
            var response = await GetRoleAssignRequest(id);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> RoleAssign(RoleAssignRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var response = await _userApiClient.RoleAssign(request.Id, request);
            /*if (response.IsSuccessed)
            {
                TempData["result"] = response.Message;
                return RedirectToAction("Index");
            }*/

            ModelState.AddModelError("", response.Message);
            var roleAssignRequest = await GetRoleAssignRequest(request.Id);
            return View(request);
        }

        private async Task<RoleAssignRequest> GetRoleAssignRequest(Guid id)
        {
            var userApiResponse = await _userApiClient.GetUserById(id);
            var roleApiResponse = await _roleApiClient.GetAll();

            var roleAssignRequest = new RoleAssignRequest();
            foreach (var role in roleApiResponse.ResultObj)
            {
                roleAssignRequest.Roles.Add(new SelectItem()
                {
                    Id = role.Id.ToString(),
                    Name = role.Name,
                    IsSelected = userApiResponse.ResultObj.Roles.Contains(role.Name)
                });
            }
            return roleAssignRequest;
        }
    }
}