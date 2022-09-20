using eShopSolution.Data.Enums;
using System.Collections.Generic;

namespace eShopSolution.Data.Entities
{
    public class Slide
    {
        public int Id { get; set; }
        public int SortOrder { get; set; }
        public Status Status { get; set; }
        public List<SlideTranslation> SlideTranslations { get; set; }

    }
}