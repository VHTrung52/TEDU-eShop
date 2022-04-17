using eShopSolution.Application.Catalog.Products;
using eShopSolution.ViewModels.Catalog.ProductImages;
using eShopSolution.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService ProductService)
        {
            _productService = ProductService;
        }

        //http://localhost:port/product/
        //[HttpGet("{languageId}")]
        //public async Task<IActionResult> GetAll(string languageId)
        //{
        //    var products = await _publicProductService.GetAll(languageId);
        //    return Ok(products);
        //}

        //http://localhost:port/product/public-paging
        [HttpGet("{languageId}")]
        public async Task<IActionResult> GetAllPaging(string languageId, [FromQuery] GetPublicProductPagingRequest request)
        {
            var response = await _productService.GetProductByCategoryId(languageId, request);
            return Ok(response);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetProductPaging(string languageId, [FromQuery] GetManageProductPagingRequest request)
        {
            var response = await _productService.GetProductPaging(request);
            return Ok(response);
        }

        //http://localhost:port/product/public/1
        [HttpGet("{productId}/{languageId}")]
        public async Task<IActionResult> GetProductById(int productId, string languageId)
        {
            var response = await _productService.GetProductById(productId, languageId);

            if (!response.IsSuccessed)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productId = await _productService.CreateProduct(request);
            if (productId == 0)
                return BadRequest();

            var product = await _productService.GetProductById(productId, request.LanguageId);

            return CreatedAtAction(nameof(GetProductById), new { id = productId }, product);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromForm] ProductUpdateRequest request)
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

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var response = await _productService.DeleteProduct(productId);

            if (!response.IsSuccessed)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPatch("{productId}/{newPrice}")]
        public async Task<IActionResult> UpdateProductPrice(int productId, decimal newPrice)
        {
            var response = await _productService.UpdateProductPrice(productId, newPrice);

            if (response)
                return Ok();

            return BadRequest();
        }

        //Images
        [HttpPost("{productId}/images")]
        public async Task<IActionResult> CreateProductImage(int productId, [FromForm] ProductImageCreateRequest request)
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

        [HttpPut("{productId}/images/{imageId}")]
        public async Task<IActionResult> UpdateImage(int imageId, [FromForm] ProductImageUpdateRequest request)
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

        [HttpDelete("{productId}/images/{imageId}")]
        public async Task<IActionResult> DeleteImage(int imageId)
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

        [HttpGet("{productId}/images/{imageId}")]
        public async Task<IActionResult> GetImageById(int productId, int imageId)
        {
            var response = await _productService.GetImageById(imageId);

            if (!response.IsSuccessed)
                return BadRequest(response);

            return Ok(response);
        }
    }
}