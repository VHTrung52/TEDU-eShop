using eShopSolution.Data.EF;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Common
{
    public abstract class BaseService
    {
        protected ILogger<BaseService> logger { get; }
        protected readonly EShopDbContext dbContext;

        public BaseService(ILogger<BaseService> lgr, EShopDbContext context)
        {
            logger = lgr;
            dbContext = context;
        }
    }
}