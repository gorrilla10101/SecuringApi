namespace ReportServices.Dtos
{
    public class ReportResultDto
    {

        public int ClientId { get; set; }
        public required string CurrencySymbol { get; set; }
        public required string ClientName { get; set; }
        public required string ReportName { get; set; }
        public bool IsCompleted { get; set; }
        public decimal Total { get; set; }
    }
}
