namespace MainApi.Dtos
{
    public class GenerateReportDto
    {
        public required string ReportName { get; set; }
        public int ClientId { get; set; }
    }
}
