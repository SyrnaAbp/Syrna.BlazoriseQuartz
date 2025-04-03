using Blazorise;
using System;
using System.Threading.Tasks;

namespace Syrna.BlazoriseQuartz.Blazor.Components
{
    public interface ITriggerDetailModelValidator
    {
        bool ValidateDaysOfWeek(TriggerDetailModel triggerModel);
        Task<string> ValidateTriggerName(string name, TriggerDetailModel triggerModel, Key triggerKey);
        Task ValidateTriggerName(ValidatorEventArgs eventArgs, TriggerDetailModel triggerModel, Key triggerKey);
        string ValidateTime(TimeSpan? start, object end, string errorMessage);
        void ValidateTime(TimeSpan? start, ValidatorEventArgs e);

        string ValidateFirstLastDateTime(TriggerDetailModel model, string errorMessage);
        void ValidateFirstLastDateTime(TriggerDetailModel model, ValidatorEventArgs e);
        //string? ValidateCronExpression(string? cronExpression);
        void ValidateCronExpression(ValidatorEventArgs eventArgs);
    }
}