using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class SlideTranslation
    {
        public int Id { set; get; }
        public int SlideId { set; get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ImagePath { get; set; }
        public string LanguageId { set; get; }
        public Slide Slide { get; set; }
        public Language Language { get; set; }
    }
}
