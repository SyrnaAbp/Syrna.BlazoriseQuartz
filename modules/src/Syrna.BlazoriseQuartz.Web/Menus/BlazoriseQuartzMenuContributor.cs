using System.Threading.Tasks;
using Syrna.BlazoriseQuartz.Authorization;
using Syrna.BlazoriseQuartz.Localization;
using Volo.Abp.UI.Navigation;

namespace Syrna.BlazoriseQuartz.Web.Menus;

public class BlazoriseQuartzMenuContributor : IMenuContributor
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
        //Add main menu items.

        if (await context.IsGrantedAsync(BlazoriseQuartzPermissions.Schedules.Default))
        {
            context.Menu.GetAdministration().AddItem(new ApplicationMenuItem(BlazoriseQuartzMenus.Prefix,
                displayName: l["Menu:Schedules"], "~/BlazoriseQuartz/Schedules/Schedules", icon: "fa fa-clock"));
        }
    }
}