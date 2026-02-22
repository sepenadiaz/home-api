namespace Home.Api.Filters
{
    public class PaginationFilter
    {
        // 1-based page number. When null, no paging is applied (return all).
        public int? PageNumber { get; set; }

        // Page size (number of items per page). Required when PageNumber is provided.
        public int? PageSize { get; set; }
    }
}
