using eShopSolution.Data.Enums;

namespace eShopSolution.Data.Entities
{
    public class Slide
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ImagePath { get; set; }
        public int SortOrder { get; set; }
        public Status Status { get; set; }
    }
}