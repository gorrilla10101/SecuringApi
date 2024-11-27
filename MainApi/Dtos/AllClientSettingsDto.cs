using ClientServices.Dtos;
using ReportServices.Dtos;

namespace MainApi.Dtos
{
    public class AllClientSettingsDto
    {
        public required ClientSettingsDto ClientSettings { get; set; }
        public required ReportSettingsDto ReportSettings { get; set; }
    }
}
