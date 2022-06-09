namespace eShopSolution.ViewModels.Common
{
    public class ApiSuccessResult<T> : ApiResult<T>
    {
        public ApiSuccessResult()
        {
            IsSuccessed = true;
        }

        public ApiSuccessResult(string msg)
        {
            Message = msg;
            IsSuccessed = true;
        }

        public ApiSuccessResult(T resultObj)
        {
            IsSuccessed = true;
            ResultObj = resultObj;
        }

        public ApiSuccessResult(string msg, T resultObj)
        {
            Message = msg;
            IsSuccessed = true;
            ResultObj = resultObj;
        }
    }
}