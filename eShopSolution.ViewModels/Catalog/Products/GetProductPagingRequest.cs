using eShopSolution.ViewModels.Common;

namespace eShopSolution.ViewModels.Catalog.Products
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    {
        //public string languageId { get; set; }
        public int? CategoryId { get; set; }
    }
}