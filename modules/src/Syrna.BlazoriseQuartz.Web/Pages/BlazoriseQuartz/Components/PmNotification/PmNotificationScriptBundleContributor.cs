using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.Modularity;

namespace Syrna.BlazoriseQuartz.Web.Pages.BlazoriseQuartz.Components.PmNotification
{
    [DependsOn(typeof(SharedThemeGlobalScriptContributor))]
    public class PmNotificationScriptBundleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddIfNotContains("/Pages/BlazoriseQuartz/Components/PmNotification/Default.js");
        }
    }
}