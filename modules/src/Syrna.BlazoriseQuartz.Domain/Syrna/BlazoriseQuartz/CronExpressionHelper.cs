using System;
using Quartz;

namespace Syrna.BlazoriseQuartz
{
    public static class CronExpressionHelper
    {
        public static bool IsValidExpression(string cronExpression)
        {
            return CronExpression.IsValidExpression(cronExpression);
        }
    }
}

