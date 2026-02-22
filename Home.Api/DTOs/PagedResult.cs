using System.Collections.Generic;
using System.Linq;

namespace Home.Api.DTOs
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
        public int TotalRecords { get; set; }
    }
}
