namespace Home.Api.Filters
{
    public class PurchaseFilter
    {
        public int? CreditCardId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        // Optional sorting
        // Example values for SortField: "Date", "Amount", "Description", "CreditCardName"
        public string? SortField { get; set; }
        // When true, sort descending; when false or null, sort ascending
        public bool? SortDescending { get; set; }
    }
}


