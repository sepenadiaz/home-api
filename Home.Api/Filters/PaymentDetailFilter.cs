namespace Home.Api.Filters
{
    public class PaymentDetailFilter : PaginationFilter
    {
        public int? Year { get; set; }
        public int? Month { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}


