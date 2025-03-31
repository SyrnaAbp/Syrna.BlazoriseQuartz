using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace Syrna.BlazoriseQuartz.Web.Pages.BlazoriseQuartz.Components.PmNotification
{
    [Widget(RefreshUrl = "/widgets/pm-notification")]
    [ViewComponent(Name = "PmNotification")]
    public class PmNotificationViewComponent : AbpViewComponent
    {
        public virtual async Task<IViewComponentResult> InvokeAsync()
        {
            return View("~/Pages/BlazoriseQuartz/Components/PmNotification/Default.cshtml");
        }
    }
}