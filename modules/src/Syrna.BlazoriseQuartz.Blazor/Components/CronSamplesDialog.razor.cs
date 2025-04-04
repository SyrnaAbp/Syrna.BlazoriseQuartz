using Blazorise;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Syrna.BlazoriseQuartz.Localization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Syrna.BlazoriseQuartz.Blazor.Components;

public partial class CronSamplesDialog
{
    [Inject] protected new IStringLocalizer<BlazoriseQuartzResource> L { get; set; }
   
    Modal modalRef;

    [Parameter] public Func<string, Task> Save { get; set; }

    private readonly List<string> _cronSamples = new()
    {
        "0 15 10 ? * *",
        "0 * 14 * * ?",
        "0 0/5 10 ? * MON-FRI",
        "0 15 10 ? * 6L",
        "0 15 10 ? * 6#3",
        "0 15 10 L-2 * ?"
    };

    public CronSamplesDialog()
    {
        LocalizationResource = typeof(BlazoriseQuartzResource);
    }

    private string GetCronDescription(string cron)
    {
        return $"{cron} ({CronExpressionDescriptor.ExpressionDescriptor.GetDescription(cron)})";
    }

    private async Task OnSelectExpression(string cronExpression)
    {
        await Save!.Invoke(cronExpression);
        await modalRef.Hide();
    }

    protected async Task Close()
    {
        await modalRef.Hide();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            modalRef?.Dispose();
        }
        base.Dispose(disposing);
    }
}