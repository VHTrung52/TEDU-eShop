using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using System;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Sevices
{
    public interface IProductApiClient
    {
        Task<ApiResult<PagedResult<ProductViewModel>>> GetProductPagings(GetManageProductPagingRequest request);

        Task<ApiResult<bool>> UpdateProduct(Guid id, ProductUpdateRequest request);

        Task<ApiResult<ProductViewModel>> GetProductById(Guid id);

        Task<ApiResult<bool>> DeleteProduct(Guid id);
    }
}