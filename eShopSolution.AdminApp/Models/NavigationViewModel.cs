using System.Collections.Generic;
using eShopSolution.ViewModels.System.Language;

namespace eShopSolution.AdminApp.Models
{
    public class NavigationViewModel
    {
        public List<LanguageViewModel> Languages { get; set; }
        public string CurrentLanguageId { get; set; }
    }
}