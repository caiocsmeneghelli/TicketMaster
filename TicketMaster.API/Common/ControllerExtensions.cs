using Microsoft.AspNetCore.Mvc;
using TicketMaster.Application.Helpers.Pagination;
using TicketMaster.Domain.Common;

namespace TicketMaster.API.Common
{
    public static class ControllerExtensions
    {
        public static IActionResult ToApiResponse<T>(this ControllerBase controller, Result<T> result)
        {
            var response = new ApiResponse<T>(result);
            if(result.IsFailure)
            {
                return controller.BadRequest(response);
            }

            return controller.Ok(response);
        }

        public static IActionResult ToApiResponse<T>(this ControllerBase controller, T data)
        {
            var response = new ApiResponse<T>(data);
            return controller.Ok(response);
        }

        public static IActionResult ToApiResponse<T>(this ControllerBase controller, PagedResult<T> pagedData)
        {
            var response = new ApiResponse<PagedResult<T>>(pagedData);
            return controller.Ok(response);
        }
    }
}
