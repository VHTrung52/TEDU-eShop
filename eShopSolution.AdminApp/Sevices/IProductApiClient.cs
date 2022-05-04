using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using System;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Sevices
{
    public interface IProductApiClient
    {
        Task<ApiResult<PagedResult<ProductViewModel>>> GetProductPagings(GetManageProductPagingRequest request);

        Task<ApiResult<bool>> UpdateProduct(int productId, ProductUpdateRequest request);

        Task<ApiResult<ProductViewModel>> GetProductById(int productId, string languageId);

        Task<ApiResult<bool>> DeleteProduct(int productId);

        Task<bool> CreateProduct(ProductCreateRequest request);

        Task<ApiResult<bool>> CategoryAssign(int productId, CategoryAssignRequest request);
    }
}