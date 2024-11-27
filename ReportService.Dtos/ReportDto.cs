﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportServices.Dtos
{
    public class ReportDto
    {
        public int ClientId { get; set; }
        public required string CurrencySymbol { get; set; }
        public required string ClientName { get; set; }
        public required string ReportName { get; set; }
    }
}
