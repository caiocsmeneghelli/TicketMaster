using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMaster.Application.Helpers.Pagination
{
    public class PagedResult<T>
    {
        public PagedResult(List<T> items, int pageNumber, int pageSize)
        {
            Items = items;
            TotalItems = items.Count;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public List<T> Items { get; set; }
        public int TotalItems { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);

    }
}
