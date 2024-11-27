namespace ReportServices.Dtos
{
    public class ReportSettingsDto
    {
        public string PreferredOutputType { get; set; } = "Excel";
        public string DateTimeFormat { get; set; } = "MM/dd/yyyy";
    }
}
