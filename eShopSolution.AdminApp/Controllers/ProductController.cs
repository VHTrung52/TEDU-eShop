using eShopSolution.AdminApp.Sevices;
using eShopSolution.Utilities.Constants;
using eShopSolution.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductApiClient _productApiClient;
        private readonly ICategoryApiClient _categoryApiClient;

        public ProductController(
            ILogger<ProductController> lgr,
            IProductApiClient productApiClient,
            ICategoryApiClient categoryApiClient)
            : base(lgr)
        {
            _productApiClient = productApiClient;
            _categoryApiClient = categoryApiClient;
        }

        public async Task<IActionResult> Index(string keyWord, int? categoryId, int pageIndex = 1, int pageSize = 10)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var request = new GetManageProductPagingRequest()
            {
                Keyword = keyWord,
                PageIndex = pageIndex,
                PageSize = pageSize,
                LanguageId = languageId,
                CategoryId = categoryId
            };
            var productData = await _productApiClient.GetProductPagings(request);
            ViewBag.KeyWord = keyWord;
            var categoryData = await _categoryApiClient.GetAllCategories(languageId);
            ViewBag.Categories = categoryData.ResultObj.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = categoryId.HasValue && categoryId.Value == x.Id
            });

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(productData.ResultObj);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _productApiClient.GetProductById(id);
            return View(result.ResultObj);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var response = await _productApiClient.CreateProduct(request);

            if (response)
            {
                TempData["result"] = "Thêm mới sản phẩm thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm mới sản phẩm thấy bại");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _productApiClient.GetProductById(id);
            if (result.IsSuccessed)
            {
                var product = result.ResultObj;
                var productUpdateRequest = new ProductUpdateRequest()
                {
                };
                return View(productUpdateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductUpdateRequest request)
        {
            /* if (!ModelState.IsValid)
                 return View();
             var result = await _productApiClient.UpdateProduct(request.Id, request);
             if (result.IsSuccessed)
             {
                 TempData["result"] = "Cập nhật người dùng thành công";
                 return RedirectToAction("Index");
             }

             ModelState.AddModelError("", result.Message);*/
            return View(request);
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            /*            return View(new Produc()
                        {
                            Id = id
                        });*/
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductUpdateRequest request)
        {
            /*if (!ModelState.IsValid)
                return View();

            var result = await _userApiClient.Delete(request.Id);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Xoá người dùng thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            return View(request);*/
            return View();
        }
    }
}