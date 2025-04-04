using Blazorise;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Syrna.BlazoriseQuartz.Localization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Components.Messages;

namespace Syrna.BlazoriseQuartz.Blazor.Components
{
    public partial class DefaultJobUI
    {
        [Inject] protected new IStringLocalizer<BlazoriseQuartzResource> L { get; set; }
        [Inject] protected IUiMessageService UiMessageService { get; set; } = default!;

        [Parameter]
        [EditorRequired]
        public JobDetailModel JobDetail { get; set; } = new();

        [Parameter] public bool IsReadOnly { get; set; }

        public async Task AddDataMap(DataMapItemModel dataMap)
        {
            if (dataMap is { Key: not null, Value: not null })
                JobDetail.JobDataMap.Add(dataMap.Key, dataMap.Value);
            else
            {
                // TODO print error message. Data map is null
            }
            await InvokeAsync(StateHasChanged);
            await Task.CompletedTask;
        }
        JobDataMapDialog JobDataMapDialogRef;
        private async Task OnAddDataMap()
        {
            var dataMapItem = new DataMapItemModel();
            await JobDataMapDialogRef.OpenModalAsync(new Dictionary<string, object>(JobDetail.JobDataMap, StringComparer.OrdinalIgnoreCase), dataMapItem, AddDataMap);
        }

        public async Task EditDataMap(DataMapItemModel dataMap)
        {
            if (dataMap is { Key: not null, Value: not null })
            {
                JobDetail.JobDataMap[dataMap.Key] = dataMap.Value;
            }
            else
            {
                // TODO print error message. Data map is null
            }
            await InvokeAsync(StateHasChanged);
            await Task.CompletedTask;
        }

        private async Task OnEditDataMap(KeyValuePair<string, object> item)
        {
            //var options = new ModalInstanceOptions
            //{
            //    Size = ModalSize.Small
            //};

            //var dialog = await ModalSvc.Show<JobDataMapDialog>("Edit Data Map", p =>
            //{
            //    p.Add("JobDataMap", JobDetail.JobDataMap);
            //    p.Add("DataMapItem", new DataMapItemModel(item));
            //    p.Add("IsEditMode", true);
            //    p.Add("Save", (Delegate)EditDataMap);

            //}, options);
            var dataMapItem = new DataMapItemModel(item);
            await JobDataMapDialogRef.OpenModalAsync(JobDetail.JobDataMap, dataMapItem, EditDataMap, true);
        }

        private async Task OnCloneDataMap(KeyValuePair<string, object> item)
        {
            var index = 1;
            var key = item.Key + index++;

            while (JobDetail.JobDataMap.ContainsKey(key))
            {
                if (index == int.MaxValue)
                {
                    key = string.Empty;
                    break;
                }

                key = item.Key + index++;
            }
            var clonedItem = new KeyValuePair<string, object>(key, item.Value);

            //var options = new ModalInstanceOptions
            //{
            //    Size = ModalSize.Small
            //};
            //await ModalSvc.Show<JobDataMapDialog>("Add Data Map", p =>
            //{
            //    p.Add("JobDataMap", new Dictionary<string, object>(JobDetail.JobDataMap, StringComparer.OrdinalIgnoreCase));
            //    p.Add("DataMapItem", new DataMapItemModel(clonedItem));
            //    p.Add("Save", (Delegate)EditDataMap);
            //}, options);
            var dataMapItem = new DataMapItemModel(clonedItem);
            await JobDataMapDialogRef.OpenModalAsync(new Dictionary<string, object>(JobDetail.JobDataMap, StringComparer.OrdinalIgnoreCase), dataMapItem, EditDataMap);
        }

        private async Task OnDeleteDataMap(KeyValuePair<string, object> item)
        {
            bool? yes = await UiMessageService.Confirm(
                $"Do you want to delete '{item.Key}'?");

            if (yes == null || !yes.Value)
            {
                return;
            }

            JobDetail.JobDataMap.Remove(item);
            await InvokeAsync(StateHasChanged);
        }
    }
}

