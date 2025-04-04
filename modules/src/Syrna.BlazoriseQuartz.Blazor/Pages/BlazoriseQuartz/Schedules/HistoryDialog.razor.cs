using Blazorise;
using Microsoft.AspNetCore.Components;
using Syrna.BlazoriseQuartz;
using Syrna.BlazoriseQuartz.Blazor.Components;
using Syrna.BlazoriseQuartz.ExecutionLog;
using Syrna.BlazoriseQuartz.ExecutionLog.Dtos;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syrna.BlazoriseQuartz.Blazor.Pages.BlazoriseQuartz.Schedules;

public partial class HistoryDialog 
{
    [Inject] private IExecutionLogAppService LogSvc { get; set; } = null!;

    [EditorRequired]
    public Key JobKey { get; set; } = null!;

    [EditorRequired]
    public Key TriggerKey { get; set; }

    private ObservableCollection<ExecutionLogDto> ExecutionLogs { get; } = new();
    private bool HasMore { get; set; }

    private PageMetadata _lastPageMeta;
    private long _firstLogId;
    Modal modalRef;

    public async Task OpenModalAsync(Key jobKey, Key triggerKey)
    {
        JobKey = jobKey;
        TriggerKey = triggerKey;
        await modalRef.Show();
        await OnRefreshHistory();
    }

    protected async Task Close()
    {
        await modalRef.Hide();
    }

    private async Task GetMoreLogs()
    {
        PageMetadata pageMeta;
        if (_lastPageMeta == null)
        {
            pageMeta = new(0, 5);
        }
        else
        {
            pageMeta = _lastPageMeta with { Page = _lastPageMeta.Page + 1 };
        }

        var result = await LogSvc.GetLatestExecutionLog(JobKey.Name,
            JobKey.Group ?? Constants.DEFAULT_GROUP,
            TriggerKey?.Name, TriggerKey?.Group,
            pageMeta, _firstLogId);

        _lastPageMeta = result.PageMetadata;
        if (pageMeta.Page == 0)
        {
            _firstLogId = result.FirstOrDefault()?.Id ?? 0;
        }

        result.ForEach(l => ExecutionLogs.Add(l));

        HasMore = result.Count == pageMeta.PageSize;
    }

    private async Task OnRefreshHistory()
    {
        ExecutionLogs.Clear();
        _lastPageMeta = null;
        _firstLogId = 0;
        HasMore = false;

        await GetMoreLogs();
    }

    ExecutionDetailsDialog ExecutionDetailsDialogRef;
    private async Task OnMoreDetails(ExecutionLogDto log, string title)
    {
        //var options = new ModalInstanceOptions
        //{
        //    Size = ModalSize.Default
        //};

        //await DialogSvc.Show<ExecutionDetailsDialog>(title, p => p.Add("ExecutionLog", log), options);
        await ExecutionDetailsDialogRef.OpenModalAsync(log);
    }

    private static string GetExecutionTime(ExecutionLogDto log)
    {
        // when fire time is available, display time range
        // otherwise just display date added
        if (log.FireTimeUtc.HasValue)
        {
            StringBuilder strBuilder = new(log.FireTimeUtc.Value.LocalDateTime.ToShortDateString() +
                    " " +
                    log.FireTimeUtc.Value.LocalDateTime.ToLongTimeString());

            var finishTime = log.GetFinishTimeUtc();
            if (finishTime.HasValue)
            {
                strBuilder.Append(" - ");
                if (finishTime.Value.LocalDateTime.Date != log.FireTimeUtc.Value.LocalDateTime.Date)
                {
                    // display ending date
                    strBuilder.Append(finishTime.Value.LocalDateTime.ToShortDateString() + " ");
                }

                strBuilder.Append(finishTime.Value.LocalDateTime.ToLongTimeString());
            }
            return strBuilder.ToString();
        }
        else
        {
            return log.DateAddedUtc.LocalDateTime.ToShortDateString() + " " +
                log.DateAddedUtc.LocalDateTime.ToLongTimeString();
        }
    }

    private static Color GetTimelineDotColor(ExecutionLogDto log)
    {
        return log.LogType switch
        {
            LogType.ScheduleJob => log.IsException ?? false ? Color.Danger : Color.Success,
            _ => Color.Default
        };
    }
}

