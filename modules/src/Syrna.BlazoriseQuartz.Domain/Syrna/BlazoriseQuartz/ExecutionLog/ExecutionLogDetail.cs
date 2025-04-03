using System;
using System.ComponentModel.DataAnnotations;

namespace Syrna.BlazoriseQuartz.ExecutionLog
{
    public class ExecutionLogDetail
    {
        public long LogId { get; set; }
        public string ExecutionDetails { get; set; }
        public string ErrorStackTrace { get; set; }
        public int? ErrorCode { get; set; }
        [MaxLength(1000)]
        public string ErrorHelpLink { get; set; }
    }
}

