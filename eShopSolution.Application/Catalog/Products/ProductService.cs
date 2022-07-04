using eShopSolution.Application.Common;
using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using eShopSolution.Utilities.Constants;
using eShopSolution.Utilities.Exceptions;
using eShopSolution.ViewModels.Catalog.Categories;
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

        public ProductService(
            ILogger<ProductService> lgr,
            EShopDbContext context,
            IStorageService storageService)
            : base(lgr, context)
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
            DbContext.ProductImages.Add(productImage);
            await DbContext.SaveChangesAsync();
            return productImage.Id;
        }

        public async Task AddProductViewCount(int productId)
        {
            var product = await DbContext.Products.FindAsync(productId);
            product.ViewCount += 1;
            await DbContext.SaveChangesAsync();
        }

        public async Task<ApiResult<int>> CreateProduct(ProductCreateRequest request)
        {
            try
            {
                var languages = DbContext.Languages;
                var productTranslations = new List<ProductTranslation>();
                foreach (var language in languages)
                {
                    if (language.Id == request.LanguageId)
                    {
                        productTranslations.Add(new ProductTranslation()
                        {
                            Name = request.Name,
                            Description = request.Description,
                            Details = request.Details,
                            SeoDescription = request.SeoDescription,
                            SeoAlias = request.SeoAlias,
                            SeoTitle = request.SeoTitle,
                            LanguageId = request.LanguageId,
                        });
                    }
                    else
                    {
                        productTranslations.Add(new ProductTranslation()
                        {
                            Name = SystemConstants.ProductConstants.NA,
                            Description = SystemConstants.ProductConstants.NA,
                            SeoAlias = SystemConstants.ProductConstants.NA,
                            LanguageId = language.Id,
                        });
                    }
                }

                var product = new Product()
                {
                    Price = request.Price,
                    OriginalPrice = request.OriginalPrice,
                    Stock = request.Stock,
                    ViewCount = 0,
                    DateCreated = DateTime.Now,
                    ProductTranslations = productTranslations
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

                DbContext.Products.Add(product);
                await DbContext.SaveChangesAsync();

                return new ApiSuccessResult<int>("Thêm mới sản phẩm thành công");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Exception in CreateProduct Service");
                throw;
            }
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            var product = await DbContext.Products.FindAsync(productId);
            if (product == null)
                return false;

            DbContext.Products.Remove(product);
            return await DbContext.SaveChangesAsync() > 0;
        }

        public async Task<ApiResult<PagedResult<ProductViewModel>>> GetProductPaging(GetManageProductPagingRequest request)
        {
            //1. Select join
            var query1 = (
                from product in DbContext.Products
                join productTranslation in DbContext.ProductTranslations
                    on product.Id equals productTranslation.ProductId
                join productInCategory in DbContext.ProductInCategories
                    on product.Id equals productInCategory.ProductId into productProductInCategory
                from productInCategory in productProductInCategory.DefaultIfEmpty()
                //join productImage in DbContext.ProductImages
                //    on product.Id equals productImage.ProductId into productProductImage
                //from productImage in productProductImage.DefaultIfEmpty()
                where
                    (productTranslation.LanguageId == request.LanguageId)
                    //&& productImage.IsDefault == true
                    && (!string.IsNullOrEmpty(request.Keyword) ? productTranslation.Name.Contains(request.Keyword) : true)
                    && ((request.CategoryId != null && request.CategoryId != 0) ? productInCategory.CategoryId == request.CategoryId : true)
                select new {
                    product,
                    productTranslation,
                    //productImage
                })
                .Distinct()
                .OrderBy(x => x.product).ThenBy(y => y.productTranslation);

            //2. paging
            int totalRow = await query1.CountAsync();

            var data = await query1
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.product.Id,
                    Name = x.productTranslation.Name,
                    DateCreated = x.product.DateCreated,
                    Description = x.productTranslation.Description,
                    Details = x.productTranslation.Details,
                    OriginalPrice = x.product.OriginalPrice,
                    Price = x.product.Price, 
                    SeoAlias = x.productTranslation.SeoAlias,
                    SeoDescription = x.productTranslation.SeoDescription,
                    SeoTitle = x.productTranslation.SeoTitle,
                    Stock = x.product.Stock,
                    ViewCount = x.product.ViewCount,
                    //ThumbnailImagePath = x.productImage.ImagePath
                })
                //.Where(y => Categories == request.CategoryId)
                .ToListAsync();

            var query2 = 
                from productInCategory in DbContext.ProductInCategories
                join category in DbContext.Categories
                    on productInCategory.CategoryId equals category.Id into productInCategoriesCategories
                from category in productInCategoriesCategories.DefaultIfEmpty()
                join categoryTranslation in DbContext.CategoryTranslations
                    on category.Id equals categoryTranslation.CategoryId into categoryCategoryTranslation
                from categoryTranslation in categoryCategoryTranslation.DefaultIfEmpty()
                where categoryTranslation.LanguageId == request.LanguageId
                select new { 
                    productInCategory,
                    categoryTranslation
                };

            foreach (ProductViewModel productViewModel in data)
            {
                var categoryViewModels = await query2
                .Where(x =>
                    x.productInCategory.ProductId == productViewModel.Id
                    && x.categoryTranslation.LanguageId == request.LanguageId)
                .Select(x => new CategoryViewModel()
                {
                    Id = x.categoryTranslation.CategoryId,
                    Name = x.categoryTranslation.Name
                }).ToListAsync();

                productViewModel.Categories.AddRange(categoryViewModels.Select(x => x.Name).ToList());
            }

            //3. select and projection
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data,
            };

            return new ApiSuccessResult<PagedResult<ProductViewModel>>(pagedResult);
        }

        public async Task<ProductViewModel> GetProductById(int productId, string languageId)
        {
            var product = await DbContext.Products.FindAsync(productId);
            if (product == null)
            {
                return null;
            }

            var productTranslation = await DbContext.ProductTranslations.FirstOrDefaultAsync(
                x => x.ProductId == productId && x.LanguageId == languageId);

            var categories = await (
                from c in DbContext.Categories
                join ct in DbContext.CategoryTranslations
                    on c.Id equals ct.CategoryId
                join pic in DbContext.ProductInCategories
                    on c.Id equals pic.CategoryId

                where
                    pic.ProductId == productId
                    && ct.LanguageId == languageId
                select ct.Name
                ).ToListAsync();

            var productImage = await DbContext.ProductImages.FirstOrDefaultAsync(x => x.ProductId == productId);

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
                ThumbnailImagePath = productImage != null ? _storageService.GetFileUrl(productImage.ImagePath) : "no-image",
                Categories = categories
            };

            return productViewModel;
        }

        public async Task<ApiResult<ProductImageViewModel>> GetImageById(int imageId)
        {
            var image = await DbContext.ProductImages.FindAsync(imageId);

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
            return await DbContext.ProductImages
                .Where(x => x.ProductId == productId)
                .Select(i => new ProductImageViewModel()
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
            var productImage = await DbContext.ProductImages.FindAsync(imageId);
            if (productImage == null)
                throw new EShopException($"Cannot find an image with id {imageId}");

            DbContext.ProductImages.Remove(productImage);
            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateProduct(ProductUpdateRequest request)
        {
            var product = await DbContext.Products.FindAsync(request.Id);
            var productTranslations = await DbContext.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Id && x.LanguageId == request.LanguageId);
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
                var thumbnailImage = await DbContext.ProductImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.ProductId == request.Id);
                if (thumbnailImage != null)
                {
                    thumbnailImage.FileSize = request.ThumbnailImage.Length;
                    thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
                    DbContext.ProductImages.Update(thumbnailImage);
                }
                else
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
            }
            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateProductImage(int imageId, ProductImageUpdateRequest request)
        {
            var productImage = await DbContext.ProductImages.FindAsync(imageId);
            if (productImage == null)
                throw new EShopException($"Cannot find an image with id {imageId}");

            if (request.ImageFile != null)
            {
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }

            DbContext.ProductImages.Update(productImage);
            return await DbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateProductPrice(int productId, decimal newPrice)
        {
            var product = await DbContext.Products.FindAsync(productId);
            if (product == null)
                throw new EShopException($"Cannot find a product with id: {productId}");

            product.Price = newPrice;
            return await DbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateProductStock(int productId, int addedQuantity)
        {
            var product = await DbContext.Products.FindAsync(productId);
            if (product == null)
                throw new EShopException($"Cannot find a product with id: {productId}");

            product.Stock += addedQuantity;
            return await DbContext.SaveChangesAsync() > 0;
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
            var query = 
                from products in DbContext.Products
                join productTranslations in DbContext.ProductTranslations
                    on products.Id equals productTranslations.ProductId
                join productInCategories in DbContext.ProductInCategories
                    on products.Id equals productInCategories.ProductId
                join categories in DbContext.Categories
                    on productInCategories.CategoryId equals categories.Id
                where productTranslations.LanguageId == languageId
                select new 
                { 
                    products, 
                    productTranslations,
                    productInCategories 
                };

            //2. filter
            if (request.CategoryId.HasValue && request.CategoryId.Value > 0)
            {
                query = query.Where(p => p.productInCategories.CategoryId == request.CategoryId);
            }

            //3. paging
            int totalRow = await query.CountAsync();

            var data = await query
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.products.Id,
                    Name = x.productTranslations.Name,
                    DateCreated = x.products.DateCreated,
                    Description = x.productTranslations.Description,
                    Details = x.productTranslations.Details,
                    OriginalPrice = x.products.OriginalPrice,
                    Price = x.products.Price,
                    SeoAlias = x.productTranslations.SeoAlias,
                    SeoDescription = x.productTranslations.SeoDescription,
                    SeoTitle = x.productTranslations.SeoTitle,
                    Stock = x.products.Stock,
                    ViewCount = x.products.ViewCount
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

        public async Task<ApiResult<bool>> CategoryAssign(int productId, CategoryAssignRequest request)
        {
            var product = await DbContext.Products.FindAsync(productId);
            if (product == null)
            {
                return new ApiErrorResult<bool>("Sản phẩm không tồn tại");
            }

            foreach (var category in request.Categories)
            {
                var productInCategory = await DbContext.ProductInCategories.FirstOrDefaultAsync(
                    x => x.ProductId == productId
                    && x.CategoryId == int.Parse(category.Id));
                if (productInCategory != null && category.IsSelected == false)
                {
                    DbContext.ProductInCategories.Remove(productInCategory);
                }
                else if (productInCategory == null && category.IsSelected == true)
                {
                    await DbContext.ProductInCategories.AddAsync(new ProductInCategory()
                    {
                        CategoryId = int.Parse(category.Id),
                        ProductId = productId,
                    });
                }
            }

            await DbContext.SaveChangesAsync();
            return new ApiSuccessResult<bool>("Cập nhật danh mục thành công");
        }

        public async Task<List<ProductViewModel>> GetFeaturedProducts(string languageId, int take)
        {
            var query = (
                from products in DbContext.Products
                join productTranslations in DbContext.ProductTranslations
                    on products.Id equals productTranslations.ProductId
                join productImages in DbContext.ProductImages
                    on products.Id equals productImages.ProductId
                    into productProductImages
                from productImages in productProductImages.DefaultIfEmpty()
                where
                    productTranslations.LanguageId == languageId
                    && (productImages == null || productImages.IsDefault == true)
                    && products.IsFeatured == true
                    //&& productImages.IsDefault == true
                select new
                {
                    products,
                    productTranslations,
                    productImages
                }
            ).OrderByDescending(x => x.products.DateCreated)
            .Take(take);

            var result = await query.Select(x => new ProductViewModel()
                {
                    Id = x.products.Id,
                    Name = x.productTranslations.Name,
                    DateCreated = x.products.DateCreated,
                    Description = x.productTranslations.Description,
                    Details = x.productTranslations.Details,
                    OriginalPrice = x.products.OriginalPrice,
                    Price = x.products.Price,
                    SeoAlias = x.productTranslations.SeoAlias,
                    SeoDescription = x.productTranslations.SeoDescription,
                    SeoTitle = x.productTranslations.SeoTitle,
                    Stock = x.products.Stock,
                    ViewCount = x.products.ViewCount,
                    ThumbnailImagePath = _storageService.GetFileUrl(x.productImages.ImagePath)
                }
            ).ToListAsync();

            return result;
        }

        public async Task<List<ProductViewModel>> GetLatestProducts(string languageId, int take)
        {
            var query = (
                from products in DbContext.Products
                join productTranslations in DbContext.ProductTranslations
                    on products.Id equals productTranslations.ProductId
                join productImages in DbContext.ProductImages
                    on products.Id equals productImages.ProductId
                    into productProductImages
                from productImages in productProductImages.DefaultIfEmpty()
                where
                    productTranslations.LanguageId == languageId
                    && (productImages == null || productImages.IsDefault == true)
                select new
                {
                    products,
                    productTranslations,
                    productImages
                }
            ).OrderByDescending(x => x.products.DateCreated)
            .Take(take);

            var result = await query.Select(x => new ProductViewModel()
                {
                    Id = x.products.Id,
                    Name = x.productTranslations.Name,
                    DateCreated = x.products.DateCreated,
                    Description = x.productTranslations.Description,
                    Details = x.productTranslations.Details,
                    OriginalPrice = x.products.OriginalPrice,
                    Price = x.products.Price,
                    SeoAlias = x.productTranslations.SeoAlias,
                    SeoDescription = x.productTranslations.SeoDescription,
                    SeoTitle = x.productTranslations.SeoTitle,
                    Stock = x.products.Stock,
                    ViewCount = x.products.ViewCount,
                    ThumbnailImagePath = _storageService.GetFileUrl(x.productImages.ImagePath)
            }
            ).ToListAsync();

            return result;
        }
    }
}