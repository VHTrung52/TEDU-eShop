using eShopSolution.ApiIntegration;
using eShopSolution.Utilities.Constants;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductApiClient _productApiClient;
        private readonly ICategoryApiClient _categoryApiClient;

        public ProductsController(
            ILogger<ProductsController> lgr,
            IProductApiClient productApiClient,
            ICategoryApiClient categoryApiClient)
            : base(lgr)
        {
            _productApiClient = productApiClient;
            _categoryApiClient = categoryApiClient;
        }

        public async Task<IActionResult> Index(string keyWord, int? categoryId, int pageIndex = 1, int pageSize = 5)
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

            var productResponse = await _productApiClient.GetProductPaging(request);
            var categoryResponse = await _categoryApiClient.GetAllCategories(languageId);

            ViewBag.KeyWord = keyWord;
            ViewBag.Categories = categoryResponse.ResultObj.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = categoryId.HasValue && categoryId.Value == x.Id
            });

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }

            return View(productResponse.ResultObj);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            //var result = await _productApiClient.GetProductById(id);
            //return View(result.ResultObj);
            throw new NotImplementedException();
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

            if (!response)
            {
                ModelState.AddModelError("", "Thêm mới sản phẩm thấy bại");
                return View(request);
            }

            TempData["result"] = "Thêm mới sản phẩm thành công";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var response = await _productApiClient.GetProductById(id, languageId);
            var request = new ProductUpdateRequest()
            {
                Id = response.ResultObj.Id,
                Description = response.ResultObj.Description,
                Details = response.ResultObj.Details,
                Name = response.ResultObj.Name,
                SeoAlias = response.ResultObj.SeoAlias,
                SeoDescription = response.ResultObj.SeoDescription,
                SeoTitle = response.ResultObj.SeoTitle,
            };
            return View(request);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit(ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var result = await _productApiClient.UpdateProduct(request.Id, request);
            if (result)
            {
                TempData["result"] = "Cập nhật sản phẩm thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Cập nhật sản phẩm thất bại");
            return View(request);
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            /*            return View(new Produc()
                        {
                            Id = id
                        });
            return View();*/
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> CategoryAssign(int productId)
        {
            var response = await GetCategoryAssignRequest(productId);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> CategoryAssign(CategoryAssignRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var response = await _productApiClient.CategoryAssign(request.ProductId, request);
            if (!response.IsSuccessed)
            {
                ModelState.AddModelError("", response.Message);
                var categoryAssignRequest = await GetCategoryAssignRequest(request.ProductId);
                return View(request);
            }

            TempData["result"] = response.Message;
            return RedirectToAction("Index");
        }

        private async Task<CategoryAssignRequest> GetCategoryAssignRequest(int productId)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            //productObj
            var productApiResponse = await _productApiClient.GetProductById(productId, languageId);
            //categoryObj
            var categoryApiResponse = await _categoryApiClient.GetAllCategories(languageId);

            var categoryAssignRequest = new CategoryAssignRequest();
            foreach (var category in categoryApiResponse.ResultObj)
            {
                categoryAssignRequest.Categories.Add(new SelectItem()
                {
                    Id = category.Id.ToString(),
                    Name = category.Name,
                    IsSelected = productApiResponse.ResultObj.Categories.Contains(category.Name)
                });
            }

            return categoryAssignRequest;
        }
    }
}