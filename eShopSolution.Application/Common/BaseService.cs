using eShopSolution.Data.EF;
using Microsoft.Extensions.Logging;

namespace eShopSolution.Application.Common
{
    public abstract class BaseService
    {
        protected ILogger<BaseService> Logger { get; }
        protected readonly EShopDbContext DbContext;

        public BaseService(ILogger<BaseService> logger, EShopDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }
    }
}