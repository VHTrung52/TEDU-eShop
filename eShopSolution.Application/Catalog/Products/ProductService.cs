using eShopSolution.Application.Common;
using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using eShopSolution.Utilities.Exceptions;
using eShopSolution.ViewModels.Catalog.ProductImages;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IStorageService _storageService;

        public ProductService(ILogger<ProductService> lgr, EShopDbContext context, IStorageService storageService) : base(lgr, context)
        {
            _storageService = storageService;
        }

        public async Task<int> AddProductImage(int productId, ProductImageCreateRequest request)
        {
            var productImage = new ProductImage()
            {
                Caption = request.Caption,
                DateCreated = DateTime.Now,
                IsDefault = request.IsDefault,
                ProductId = productId,
                SortOrder = request.SortOrder,
            };
            if (request.ImageFile != null)
            {
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }
            dbContext.ProductImages.Add(productImage);
            await dbContext.SaveChangesAsync();
            return productImage.Id;
        }

        public async Task AddProductViewCount(int productId)
        {
            var product = await dbContext.Products.FindAsync(productId);
            product.ViewCount += 1;
            await dbContext.SaveChangesAsync();
        }

        public async Task<ApiResult<int>> CreateProduct(ProductCreateRequest request)
        {
            try
            {
                var product = new Product()
                {
                    Price = request.Price,
                    OriginalPrice = request.OriginalPrice,
                    Stock = request.Stock,
                    ViewCount = 0,
                    DateCreated = DateTime.Now,
                    ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Name = request.Name,
                        Description = request.Description,
                        Details = request.Details,
                        SeoDescription = request.SeoDescription,
                        SeoAlias = request.SeoAlias,
                        SeoTitle = request.SeoTitle,
                        LanguageId = request.LanguageId,
                    }
                }
                };

                //Save image
                if (request.ThumbnailImage != null)
                {
                    product.ProductImages = new List<ProductImage>()
                    {
                        new ProductImage()
                        {
                            Caption = "Thumbnail image",
                            DateCreated = DateTime.Now,
                            FileSize = request.ThumbnailImage.Length,
                            ImagePath = await this.SaveFile(request.ThumbnailImage),
                            IsDefault = true,
                            SortOrder = 1
                        }
                    };
                }

                dbContext.Products.Add(product);
                await dbContext.SaveChangesAsync();

                return new ApiSuccessResult<int>("Thêm mới sản phẩm thành công");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in CreateProduct Service");
                throw;
            }
        }

        public async Task<ApiResult<int>> DeleteProduct(int productId)
        {
            var product = await dbContext.Products.FindAsync(productId);
            if (product == null)
                return new ApiErrorResult<int>($"Cannot find product: {productId}");

            dbContext.Products.Remove(product);
            var result = await dbContext.SaveChangesAsync();
            return new ApiSuccessResult<int>(result);
        }

        public async Task<ApiResult<PagedResult<ProductViewModel>>> GetProductPaging(GetManageProductPagingRequest request)
        {
            //1. Select join
            var query = from p in dbContext.Products
                        join pt in dbContext.ProductTranslations on p.Id equals pt.ProductId
                        //join pic in dbContext.ProductInCategories on p.Id equals pic.ProductId
                        //join c in dbContext.Categories on pic.CategoryId equals c.Id
                        where pt.LanguageId == request.LanguageId
                        select new { p, pt };
            //--select new { p, pt, pic };
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));

            /*if (request.CategoryIds != null && request.CategoryIds.Count > 0)
            {
                query = query.Where(p => request.CategoryIds.Contains(p.pic.CategoryId));
            }*/

            //3. paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount
                }).ToListAsync();
            //4. select and projection
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data,
            };

            return new ApiSuccessResult<PagedResult<ProductViewModel>>(pagedResult);
        }

        public async Task<ApiResult<ProductViewModel>> GetProductById(int productId, string languageId)
        {
            var product = await dbContext.Products.FindAsync(productId);
            if (product == null)
            {
                return new ApiErrorResult<ProductViewModel>("Sản phẩm không tồn tại");
            }

            var productTranslation = await dbContext.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == productId && x.LanguageId == languageId);
            var productViewModel = new ProductViewModel()
            {
                Id = product.Id,
                DateCreated = product.DateCreated,
                Description = productTranslation != null ? productTranslation.Description : null,
                LanguageId = productTranslation.LanguageId,
                Details = productTranslation != null ? productTranslation.Details : null,
                Name = productTranslation != null ? productTranslation.Name : null,
                OriginalPrice = product.OriginalPrice,
                Price = product.Price,
                SeoAlias = productTranslation != null ? productTranslation.SeoAlias : null,
                SeoDescription = productTranslation != null ? productTranslation.SeoDescription : null,
                SeoTitle = productTranslation != null ? productTranslation.SeoTitle : null,
                Stock = product.Stock,
                ViewCount = product.ViewCount,
            };

            return new ApiSuccessResult<ProductViewModel>(productViewModel);
        }

        public async Task<ApiResult<ProductImageViewModel>> GetImageById(int imageId)
        {
            var image = await dbContext.ProductImages.FindAsync(imageId);

            if (image == null)
                return new ApiErrorResult<ProductImageViewModel>("Ảnh không tồn tại");

            var productImageViewModel = new ProductImageViewModel()
            {
                Caption = image.Caption,
                DateCreated = image.DateCreated,
                FileSize = image.FileSize,
                Id = image.Id,
                ImagePath = image.ImagePath,
                IsDefault = image.IsDefault,
                ProductId = image.ProductId,
                SortOrder = image.SortOrder
            };

            return new ApiSuccessResult<ProductImageViewModel>(productImageViewModel); ;
        }

        public async Task<List<ProductImageViewModel>> GetProductImage(int productId)
        {
            return await dbContext.ProductImages.Where(x => x.ProductId == productId).
                Select(i => new ProductImageViewModel()
                {
                    Caption = i.Caption,
                    DateCreated = i.DateCreated,
                    FileSize = i.FileSize,
                    Id = i.Id,
                    ImagePath = i.ImagePath,
                    IsDefault = i.IsDefault,
                    ProductId = i.ProductId,
                    SortOrder = i.SortOrder
                }).ToListAsync();
        }

        public async Task<int> DeleteImage(int imageId)
        {
            var productImage = await dbContext.ProductImages.FindAsync(imageId);
            if (productImage == null)
                throw new EShopException($"Cannot find an image with id {imageId}");

            dbContext.ProductImages.Remove(productImage);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateProduct(ProductUpdateRequest request)
        {
            var product = await dbContext.Products.FindAsync(request.Id);
            var productTranslations = await dbContext.ProductTranslations.FirstOrDefaultAsync(
                x => x.ProductId == request.Id
                && x.LanguageId == request.LanguageId);
            if (product == null || productTranslations == null)
                throw new EShopException($"Cannot find a product with id: {request.Id}");

            productTranslations.Name = request.Name;
            productTranslations.SeoAlias = request.SeoAlias;
            productTranslations.SeoDescription = request.SeoDescription;
            productTranslations.SeoTitle = request.SeoTitle;
            productTranslations.Details = request.Details;

            //Save image
            if (request.ThumbnailImage != null)
            {
                var thumbnailImage = await dbContext.ProductImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.ProductId == request.Id);
                if (thumbnailImage != null)
                {
                    thumbnailImage.FileSize = request.ThumbnailImage.Length;
                    thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
                    dbContext.ProductImages.Update(thumbnailImage);
                }
            }

            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateProductImage(int imageId, ProductImageUpdateRequest request)
        {
            var productImage = await dbContext.ProductImages.FindAsync(imageId);
            if (productImage == null)
                throw new EShopException($"Cannot find an image with id {imageId}");

            if (request.ImageFile != null)
            {
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }

            dbContext.ProductImages.Update(productImage);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateProductPrice(int productId, decimal newPrice)
        {
            var product = await dbContext.Products.FindAsync(productId);
            if (product == null)
                throw new EShopException($"Cannot find a product with id: {productId}");

            product.Price = newPrice;
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateProductStock(int productId, int addedQuantity)
        {
            var product = await dbContext.Products.FindAsync(productId);
            if (product == null)
                throw new EShopException($"Cannot find a product with id: {productId}");

            product.Stock += addedQuantity;
            return await dbContext.SaveChangesAsync() > 0;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

        public async Task<PagedResult<ProductViewModel>> GetProductByCategoryId(string languageId, GetPublicProductPagingRequest request)
        {
            //1. Select join
            var query = from p in dbContext.Products
                        join pt in dbContext.ProductTranslations
                            on p.Id equals pt.ProductId
                        join pic in dbContext.ProductInCategories
                            on p.Id equals pic.ProductId
                        join c in dbContext.Categories
                            on pic.CategoryId equals c.Id
                        where pt.LanguageId == languageId
                        select new { p, pt, pic };

            //2. filter
            if (request.CategoryId.HasValue && request.CategoryId.Value > 0)
            {
                query = query.Where(p => p.pic.CategoryId == request.CategoryId);
            }

            //3. paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount
                }).ToListAsync();
            //4. select and projection
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data,
            };

            return pagedResult;
        }
    }
}