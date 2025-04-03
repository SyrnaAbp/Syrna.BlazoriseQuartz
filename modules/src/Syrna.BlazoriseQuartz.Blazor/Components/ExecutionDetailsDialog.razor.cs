using Blazorise;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Syrna.BlazoriseQuartz.Blazor.Components;

public partial class ExecutionDetailsDialog
{
	[Inject] private IModalService ModalService { get; set; } = null!;

	[EditorRequired] [Parameter] public ExecutionLog.ExecutionLog ExecutionLog { get; set; } = new();

    protected async Task Close()
    {
        await ModalService.Hide();
    }
}