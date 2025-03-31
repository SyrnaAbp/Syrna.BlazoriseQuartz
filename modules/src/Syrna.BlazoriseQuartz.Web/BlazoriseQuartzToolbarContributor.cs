using System.Threading.Tasks;
using Syrna.BlazoriseQuartz.Authorization;
using Syrna.BlazoriseQuartz.Web.Pages.BlazoriseQuartz.Components.PmNotification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;

namespace Syrna.BlazoriseQuartz.Web
{
    public class BlazoriseQuartzToolbarContributor : IToolbarContributor
    {
        public virtual async Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
        {
            if (context.Toolbar.Name != StandardToolbars.Main)
            {
                return;
            }

            if (await context.IsGrantedAsync(
                BlazoriseQuartzPermissions.PrivateMessageNotifications.Default))
            {
                context.Toolbar.Items.Insert(0, new ToolbarItem(typeof(PmNotificationViewComponent)));
            }
        }
    }
}