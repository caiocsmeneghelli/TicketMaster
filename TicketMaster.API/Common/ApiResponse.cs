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

        public ApiResponse(List<T> data)
        {
            Success = true;
            Data = (T)(object)data;
            Errors = new List<string>();
        }

        public static ApiResponse<T> FromResult(Result<T> result)
        {
            return new ApiResponse<T>(result);
        }

        public static ApiResponse<T> FromList(List<T> data)
        {
            return new ApiResponse<T>(data);
        }
    }
} 