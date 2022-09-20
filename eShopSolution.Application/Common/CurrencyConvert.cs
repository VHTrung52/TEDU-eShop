using eShopSolution.Utilities.Constants;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Common
{
    public class CurrencyConvert : ICurrencyConvert
    {
        private readonly IConfiguration _configuration;

        public CurrencyConvert(
            IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public decimal ConvertVndToUsd(decimal vndPrice)
        {
            return vndPrice * SystemConstants.ExchangeRateVndToUsd.Rate;
        }
    }
}
