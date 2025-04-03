using System.Threading.Tasks;
using Syrna.BlazoriseQuartz.Localization;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.UI.Navigation;
using Syrna.BlazoriseQuartz.MainDemo.MultiTenancy;
using Blazorise;
using Volo.Abp.Authorization.Permissions;
using Syrna.BlazoriseQuartz.Authorization;

namespace Syrna.BlazoriseQuartz.MainDemo.Blazor.Server.Host.Menus
{
    public class MainDemoMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<BlazoriseQuartzResource>();
            var administration = context.Menu.GetAdministration();

            if (MultiTenancyConsts.IsEnabled)
            {
                administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
            }
            else
            {
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
            administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

            var groupMenuItem = new ApplicationMenuItem(MainDemoMenus.Prefix, l["Menu:BlazoriseQuartz"],
                icon: IconName.Clock.ToString());
            context.Menu.AddItem(groupMenuItem);

            groupMenuItem.AddItem(new ApplicationMenuItem(
                MainDemoMenus.Overview,
                l["Menu:Overview"],
                url: "~/overview").RequirePermissions(BlazoriseQuartzPermissions.Overview.Default));

            groupMenuItem.AddItem(new ApplicationMenuItem(
                MainDemoMenus.Schedules,
                l["Menu:Schedules"],
                url: "~/schedules").RequirePermissions(BlazoriseQuartzPermissions.Schedules.Default));

            groupMenuItem.AddItem(new ApplicationMenuItem(
                MainDemoMenus.History,
                l["Menu:History"],
                url: "~/history").RequirePermissions(BlazoriseQuartzPermissions.History.Default));

        }
    }
}
