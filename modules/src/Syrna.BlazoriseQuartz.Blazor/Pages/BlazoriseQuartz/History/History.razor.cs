using Blazorise;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Syrna.BlazoriseQuartz.Blazor.Components;
using Syrna.BlazoriseQuartz.ExecutionLog;
using Syrna.BlazoriseQuartz.ExecutionLog.Dtos;
using Syrna.BlazoriseQuartz.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Syrna.BlazoriseQuartz.Blazor.Pages.BlazoriseQuartz.History
{
    public partial class History
    {
        [Inject] protected new IStringLocalizer<BlazoriseQuartzResource> L { get; set; }
        [Inject] IExecutionLogAppService LogSvc { get; set; } = null!;

        private PagedList<ExecutionLogDto> pagedData;
        private DataGrid<ExecutionLogDto> table = null!;

        private long _firstLogId;

        private int totalItems;
        private int pageSize = 10;
        private bool _openFilter;

        private ExecutionLogFilter _filter = new();
        private ExecutionLogFilter _origFilter = new();
        private LogType? _selectedLogType;
        private IEnumerable<string> _jobNames = [];
        private IEnumerable<string> _jobGroups = [];
        private IEnumerable<string> _triggerNames = [];
        private IEnumerable<string> _triggerGroups = [];

        async Task OnReadData()
        {
            PageMetadata pageMeta;
            var state = await table.GetState();
            if (pagedData == null)
            {
                pageMeta = new PageMetadata(0, state.PageSize);
            }
            else
            {
                pageMeta = pagedData.PageMetadata! with { Page = state.CurrentPage - 1, PageSize = state.PageSize };
            }

            pagedData = await LogSvc.GetExecutionLogs(_filter, pageMeta, _firstLogId);

            if (pageMeta.Page == 0)
            {
                _firstLogId = pagedData.FirstOrDefault()?.Id ?? 0;
            }

            ArgumentNullException.ThrowIfNull(pagedData.PageMetadata);

            totalItems = pagedData.PageMetadata.TotalCount;
        }

        private async Task OnSearch(string text)
        {
            _filter.MessageContains = text;
            await RefreshLogs();
        }

        private async Task RefreshLogs()
        {
            pagedData = null;
            _firstLogId = 0;
            await table.ReadData.InvokeAsync();
        }

        private static (IconName, TextColor, string) GetLogIconAndColor(ExecutionLogDto log)
        {
            if (log.IsException ?? log.IsSuccess.HasValue && !log.IsSuccess.Value)
                return (IconName.ExclamationCircle, TextColor.Danger, "Error");

            switch (log.LogType)
            {
                case LogType.ScheduleJob:
                    if (log.IsVetoed ?? false)
                        return (IconName.InfoCircle, TextColor.Warning, "Vetoed");

                    return log.IsSuccess is null ?
                        // still running
                        (IconName.Palette, TextColor.Secondary, "Executing") : (IconName.Check, TextColor.Info, "Success");
                case LogType.Trigger:
                    return (IconName.Alert, TextColor.Warning, "Trigger");
                default:
                    return (IconName.Info, TextColor.Warning, "System Info");
            }
        }

        ExecutionDetailsDialog ExecutionDetailsDialogRef;
        private async Task OnMoreDetails(ExecutionLogDto log, string titleSuffix)
        {
            await ExecutionDetailsDialogRef.OpenModalAsync(log, titleSuffix);
        }

        public History()
        {
            LocalizationResource = typeof(BlazoriseQuartzResource);
        }

        #region Filters
        private async Task OnFilterClicked()
        {
            // backup original filter
            _origFilter = (ExecutionLogFilter)_filter.Clone();

            if (!_jobNames.Any())
            {
                // load filter
                await ReloadFilters();
            }

            _openFilter = true;
        }

        private void OnSaveFilter()
        {
            _openFilter = false;
        }

        private async Task OnClearFilter()
        {
            _filter = new();
            await RefreshLogs();
            _openFilter = false;
        }

        private async Task OnCancelFilter()
        {
            _filter = _origFilter;
            await RefreshLogs();
            _openFilter = false;
        }

        private async Task ReloadFilters()
        {
            _jobNames = await LogSvc.GetJobNames();
            _jobGroups = await LogSvc.GetJobGroups();
            _triggerNames = await LogSvc.GetTriggerNames();
            _triggerGroups = await LogSvc.GetTriggerGroups();
        }

        private async Task OnFilterJobGroupChanged(string value)
        {
            _filter.JobGroup = value;
            await RefreshLogs();
        }

        private async Task OnFilterJobNameChanged(string value)
        {
            _filter.JobName = value;
            await RefreshLogs();
        }

        private async Task OnFilterTriggerGroupChanged(string value)
        {
            _filter.TriggerGroup = value;
            await RefreshLogs();
        }

        private async Task OnFilterTriggerNameChanged(string value)
        {
            _filter.TriggerName = value;
            await RefreshLogs();
        }

        private async Task OnSelectedLogTypesChanged(LogType? logTypes)
        {
            _selectedLogType = logTypes;
            if (logTypes == null)
                _filter.LogTypes = null;
            else
                _filter.LogTypes = new HashSet<LogType> { logTypes.Value };

            await RefreshLogs();
        }

        private async Task OnErrorOnlyChanged(bool errorOnly)
        {
            _filter.ErrorOnly = errorOnly;
            await RefreshLogs();
        }

        private async Task OnIncludeSystemJobsChanged(bool flag)
        {
            _filter.IncludeSystemJobs = flag;
            await RefreshLogs();
        }
        #endregion Filters
        //private Task OnPageChanged(DataGridPageChangedEventArgs args)
        //{
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //modalRef?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

