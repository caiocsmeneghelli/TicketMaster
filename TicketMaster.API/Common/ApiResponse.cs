using TicketMaster.Application.Helpers.Pagination;
using TicketMaster.Domain.Common;

namespace TicketMaster.API.Common
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Error { get; set; }
        public List<string> Errors { get; set; }

        public ApiResponse(Result<T> result)
        {
            Success = result.IsSuccess;
            if (result.IsSuccess)
            {
                Data = result.Value;
            }
            else
            {
                Error = result.Error;
                Errors = result.Errors.ToList();
            }
        }

        public ApiResponse(T data)
        {
            Success = true;
            Data = data;
            Errors = new List<string>();
        }

        public ApiResponse(PagedResult<T> result)
        {
            Success = true;
            Data = (T)(object)result;
            Errors = new List<string>();
        }

        public static ApiResponse<T> FromResult(Result<T> result)
        {
            return new ApiResponse<T>(result);
        }

        public static ApiResponse<T> FromObject(T data)
        {
            return new ApiResponse<T>(data);
        }
    }
} 