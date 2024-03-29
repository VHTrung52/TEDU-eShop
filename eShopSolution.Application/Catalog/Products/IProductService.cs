﻿using eShopSolution.ViewModels.Catalog.ProductImages;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public interface IProductService
    {
        Task<ApiResult<int>> CreateProduct(ProductCreateRequest request);

        Task<int> UpdateProduct(ProductUpdateRequest request);

        Task<bool> DeleteProduct(int productId);

        Task<bool> UpdateProductPrice(int productId, decimal newPrice);

        Task<bool> UpdateProductStock(int productId, int addedQuantity);

        Task AddProductViewCount(int productId);

        Task<ApiResult<PagedResult<ProductViewModel>>> GetProductPaging(GetManageProductPagingRequest request);

        Task<ProductViewModel> GetProductById(int productId, string languageId);

        Task<int> AddProductImage(int productId, ProductImageCreateRequest request);

        Task<int> UpdateProductImage(int imageId, ProductImageUpdateRequest request);

        Task<int> DeleteImage(int imageId);

        Task<List<ProductImageViewModel>> GetProductImage(int productId);

        Task<ApiResult<ProductImageViewModel>> GetImageById(int imageId);

        Task<PagedResult<ProductViewModel>> GetProductByCategoryId(string languageId, GetPublicProductPagingRequest request);

        Task<ApiResult<bool>> CategoryAssign(int productId, CategoryAssignRequest request);

        Task<List<ProductViewModel>> GetFeaturedProducts(string languageId, int take);

        Task<List<ProductViewModel>> GetLatestProducts(string languageId, int take);

    }
}