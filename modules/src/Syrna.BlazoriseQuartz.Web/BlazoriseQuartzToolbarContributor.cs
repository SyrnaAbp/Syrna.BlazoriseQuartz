using Syrna.BlazoriseQuartz.Authorization;
using System.Threading.Tasks;
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
                BlazoriseQuartzPermissions.Schedules.Default))
            {
                //context.Toolbar.Items.Insert(0, new ToolbarItem(typeof(PmNotificationViewComponent)));
            }
        }
    }
}