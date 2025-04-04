using Blazorise;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Syrna.BlazoriseQuartz.ExecutionLog.Dtos;
using Syrna.BlazoriseQuartz.Localization;
using System.Threading.Tasks;

namespace Syrna.BlazoriseQuartz.Blazor.Components;

public partial class ExecutionDetailsDialog
{
    [Inject]
    protected new IStringLocalizer<BlazoriseQuartzResource> L { get; set; }

    Modal modalRef;

	public ExecutionLogDto ExecutionLog { get; set; } = new();

    public ExecutionDetailsDialog()
    {
        LocalizationResource = typeof(BlazoriseQuartzResource);
    }

    public async Task OpenModalAsync(ExecutionLogDto executionLog)
    {
        ExecutionLog = executionLog;
        await modalRef.Show();
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