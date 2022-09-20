using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Common
{
    public interface ICurrencyConvert
    {
        public decimal ConvertVndToUsd(decimal vndPrice);
    }
}
