using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacies.Models
{
    public class ReportingPeriod
    {
        public int Id { get; set; }

        public int Quarter { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

    }
}
