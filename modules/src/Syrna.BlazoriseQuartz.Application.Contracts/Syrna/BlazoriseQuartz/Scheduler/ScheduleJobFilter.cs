using System;
namespace Syrna.BlazoriseQuartz.Scheduler
{
    public class ScheduleJobFilter : ICloneable
    {
        public bool IncludeSystemJobs { get; set; } = false;

        public object Clone()
        {
            return (ScheduleJobFilter)MemberwiseClone();
        }
    }
}

