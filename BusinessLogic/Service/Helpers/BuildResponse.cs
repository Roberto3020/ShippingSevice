using BusinessLogic.Model;
using Tranversal.Enums;
namespace BusinessLogic.Service.Helpers
{
    public class BuildResponse
    {
        public static ServiceResponse<T?> FromResult<T>(T? data, ResultState state = ResultState.Success, string? message = null)
        {
            var response = new ServiceResponse<T?>
            {
                Data = data,
                State = state,
                Message = message ?? state.GetDescription() ?? state.ToString(),
            };

            return response;
        }

        public static ServiceResponse<T?> Error<T>(T? data = null, string? message = null) where T : class
        {
            return FromResult(data, ResultState.Error, message);
        }

        public static ServiceResponse<T?> Error<T>(string? message = null) where T : class
        {
            return FromResult<T>(null, ResultState.Error, message);
        }

        public static ServiceResponse<T> Success<T>(T data, string? message = null) where T : class
        {
            var state = ResultState.Success;

            var response = new ServiceResponse<T>
            {
                Data = data,
                State = ResultState.Success,
                Message = message ?? state.GetDescription() ?? state.ToString(),
            };

            return response;
        }

        public static ServiceResponse Error(string? message = null)
        {
            var response = new ServiceResponse
            {
                State = ResultState.Error,
                Message = message ?? ResultState.Error.GetDescription() ?? ResultState.Error.ToString(),
            };

            return response;
        }

        public static ServiceResponse Success(string? message = null)
        {
            var response = new ServiceResponse
            {
                State = ResultState.Success,
                Message = message ?? ResultState.Success.GetDescription() ?? ResultState.Success.ToString(),
            };

            return response;
        }


        public static ServiceResponse<IEnumerable<T>?> List<T>(IEnumerable<T>? data, ResultState state = ResultState.Success, string? message = null)
        {
            var response = new ServiceResponse<IEnumerable<T>?>
            {
                Data = data,
                State = state,
                Message = message ?? state.GetDescription() ?? state.ToString(),
            };

            return response;
        }
    }
}
