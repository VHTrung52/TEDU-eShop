using Microsoft.AspNetCore.Http;

namespace eShopSolution.ViewModels.Catalog.Products
{
    public class ProductCreateRequest
    {
        public string Name { set; get; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public int Stock { get; set; }
        public string Description { set; get; }
        public string Details { set; get; }
        public bool? IsFeatured { get; set; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string SeoAlias { get; set; }
        public string LanguageId { set; get; }
        public IFormFile ThumbnailImage { set; get; }
    }
}