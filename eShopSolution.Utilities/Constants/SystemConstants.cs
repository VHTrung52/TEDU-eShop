namespace eShopSolution.Utilities.Constants
{
    public class SystemConstants
    {
        public const string MainConnectionString = "eShopSolutionDb";
        public const string CartSession = "CartSession";

        public class AppSettings
        {
            public const string DefaultLanguageId = "DefaultLanguageId";
            public const string Token = "Token";
            public const string BaseAddress = "BaseAddress";
            public const string UserContentFolder = "UserContentFolder";
            public const string ProductImage = "ProductImage";
            public const string CarouselImage = "CarouselImage";
        }

        public class ProductSettings
        {
            public const int NumberOfFeaturedProducts = 8;
            public const int NumberOfLatestProducts = 9;
        }

        public class ProductConstants
        {
            public const string NA = "N/A";
        }

        public class ExchangeRateVndToUsd
        {
            public const decimal Rate = 4.347826086956522e-5M;
        }

        public class LanguageId
        {
            public const string Vi = "vi";
            public const string En = "en";
        }
    }
}