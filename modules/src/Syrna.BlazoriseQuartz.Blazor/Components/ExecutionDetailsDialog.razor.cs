using Blazorise;
using Microsoft.AspNetCore.Components;
using Syrna.BlazoriseQuartz.ExecutionLog.Dtos;
using System.Threading.Tasks;

namespace Syrna.BlazoriseQuartz.Blazor.Components;

public partial class ExecutionDetailsDialog
{
    Modal modalRef;

	public ExecutionLogDto ExecutionLog { get; set; } = new();

    public void Open(ExecutionLogDto executionLog)
    {
        ExecutionLog = executionLog;
        modalRef.Show();
    }

    protected async Task Close()
    {
        await modalRef.Hide();
    }
}