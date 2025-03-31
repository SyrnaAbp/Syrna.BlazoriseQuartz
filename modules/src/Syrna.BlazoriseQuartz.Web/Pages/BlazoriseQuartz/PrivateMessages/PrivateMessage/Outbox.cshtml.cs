using System.Threading.Tasks;

namespace Syrna.BlazoriseQuartz.Web.Pages.BlazoriseQuartz.PrivateMessages.PrivateMessage
{
    public class OutboxModel : BlazoriseQuartzPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
