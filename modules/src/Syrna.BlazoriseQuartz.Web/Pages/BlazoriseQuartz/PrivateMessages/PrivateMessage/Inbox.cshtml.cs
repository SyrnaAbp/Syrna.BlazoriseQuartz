using System.Threading.Tasks;

namespace Syrna.BlazoriseQuartz.Web.Pages.BlazoriseQuartz.PrivateMessages.PrivateMessage
{
    public class InboxModel : BlazoriseQuartzPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
