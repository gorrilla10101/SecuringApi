using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Dto
{
    public class ReportDto
    {
        public required string ClientId { get; set; }
        public required string CurrencySymbol { get; set; }
        public required string ClientName { get; set; }

    }
}
