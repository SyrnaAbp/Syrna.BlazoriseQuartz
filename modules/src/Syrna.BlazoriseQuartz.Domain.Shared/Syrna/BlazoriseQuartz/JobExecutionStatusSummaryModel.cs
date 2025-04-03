using System;
using System.Collections.Generic;

namespace Syrna.BlazoriseQuartz
{
    public class JobExecutionStatusSummaryModel
    {
        public DateTime StartDateTimeUtc { get; set; }
        public List<KeyValuePair<JobExecutionStatus, int>> Data { get; set; } = new();
    }
}

