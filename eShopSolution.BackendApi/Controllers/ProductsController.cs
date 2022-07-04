using eShopSolution.Application.Catalog.Products;
using eShopSolution.ViewModels.Catalog.ProductImages;
using eShopSolution.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductsController : BaseController
    {
        private readonly IProductService _productService;

        public ProductsController(
            ILogger<ProductsController> logger,
            IProductService ProductService)
            : base(logger)
        {
            _productService = ProductService;
        }

        [HttpGet("{languageId}")]
        public async Task<IActionResult> GetAllPaging(string languageId, [FromQuery] GetPublicProductPagingRequest request)
        {
            var response = await _productService.GetProductByCategoryId(languageId, request);
            return Ok(response);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetProductPaging([FromQuery] GetManageProductPagingRequest request)
        {
            try
            {
                var response = await _productService.GetProductPaging(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception in BackendApi\\ProductsController\\GetProductPaging");
                return ServerError();
            }
        }

        //http://localhost:port/product/public/1
        [HttpGet("{productId}/{languageId}")]
        public async Task<IActionResult> GetProductById(int productId, string languageId)
        {
            try
            {
                var response = await _productService.GetProductById(productId, languageId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception in BackendApi\\ProductsController\\GetProductById for productId, languageId: {productId}, {languageId}");
                return ServerError();
            }
        }

        [HttpGet("featured/{languageId}/{take}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFeaturedProducts(string languageId, int take)
        {
            try
            {
                var response = await _productService.GetFeaturedProducts(languageId, take);
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception in BackendApi\\ProductsController\\GetFeaturedProduct for languageId: {languageId}");
                return ServerError();
            }
        }

        [HttpGet("latest/{languageId}/{take}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLatestProducts(string languageId, int take)
        {
            try
            {
                var response = await _productService.GetLatestProducts(languageId, take);
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception in BackendApi\\ProductsController\\GetLatestProduct for languageId: {languageId}");
                return ServerError();
            }
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> CreateProduct([FromForm] ProductCreateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var response = await _productService.CreateProduct(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in BackendApi\\ProductsController\\CreateProduct");
                return ServerError();
            }
        }

        [HttpPut]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> UpdateProduct([FromForm] ProductUpdateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var response = await _productService.UpdateProduct(request);

                if (response == 0)
                    return BadRequest();

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception in BackendApi\\ProductsController\\UpdateProduct for productId: {request.Id}");
                return ServerError();
            }
        }

        [HttpDelete("{productId}")]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            try
            {
                var response = await _productService.DeleteProduct(productId);

                if (!response)
                    return BadRequest(response);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception in BackendApi\\ProductsController\\DeleteProduct for productId: {productId}");
                return ServerError();
            }
        }

        [HttpPatch("{productId}/{newPrice}")]
        [Authorize]
        public async Task<IActionResult> UpdateProductPrice(int productId, decimal newPrice)
        {
            try
            {
                var response = await _productService.UpdateProductPrice(productId, newPrice);

                if (response)
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception in BackendApi\\ProductsController\\UpdateProductPrice for productId: {productId}");
                return ServerError();
            }
        }

        //Images
        [HttpPost("{productId}/images")]
        [Authorize]
        public async Task<IActionResult> CreateProductImage(int productId, [FromForm] ProductImageCreateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var imageId = await _productService.AddProductImage(productId, request);
                if (productId == 0)
                    return BadRequest();

                var product = await _productService.GetImageById(imageId);

                return CreatedAtAction(nameof(GetImageById), new { id = imageId }, imageId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception in BackendApi\\ProductsController\\CreateProductImage for productId: {productId}");
                return ServerError();
            }
        }

        [HttpPut("{productId}/images/{imageId}")]
        [Authorize]
        public async Task<IActionResult> UpdateImage(int imageId, [FromForm] ProductImageUpdateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _productService.UpdateProductImage(imageId, request);
                if (result == 0)
                    return BadRequest();

                var product = await _productService.GetImageById(imageId);

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception in BackendApi\\ProductsController\\UpdateImage for imageId: {imageId}");
                return ServerError();
            }
        }

        [HttpDelete("{productId}/images/{imageId}")]
        [Authorize]
        public async Task<IActionResult> DeleteImage(int imageId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var response = await _productService.DeleteImage(imageId);

                if (response == 0)
                    return BadRequest();

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception in BackendApi\\ProductsController\\DeleteImage for imageId: {imageId}");
                return ServerError();
            }
        }

        [HttpGet("{productId}/images/{imageId}")]
        public async Task<IActionResult> GetImageById(int productId, int imageId)
        {
            try
            {
                var response = await _productService.GetImageById(imageId);

                if (!response.IsSuccessed)
                    return BadRequest(response);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception in BackendApi\\ProductsController\\GetImageById for productId, imageId: {productId}, {imageId}");
                return ServerError();
            }
        }

        [HttpPut("{productId}/categories")]
        [Authorize]
        public async Task<IActionResult> CategoryAssign(int productId, [FromBody] CategoryAssignRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _productService.CategoryAssign(productId, request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception in BackendApi\\ProductsController\\CategoryAssign for productId: {productId}");
                return ServerError();
            }
        }
    }
}