using System.Threading.Tasks;
using Syrna.BlazoriseQuartz.Authorization;
using Syrna.BlazoriseQuartz.Blazor.Components;
using Volo.Abp.AspNetCore.Components.Web.Theming.Toolbars;

namespace Syrna.BlazoriseQuartz.Blazor
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