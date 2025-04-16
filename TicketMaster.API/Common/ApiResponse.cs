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

        public static ApiResponse<T> FromResult(Result<T> result)
        {
            return new ApiResponse<T>(result);
        }
    }
} 