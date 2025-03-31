using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Syrna.BlazoriseQuartz.Localization;
using Syrna.BlazoriseQuartz.Web.Pages.BlazoriseQuartz.Components.PmNotification;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Syrna.BlazoriseQuartz.Web
{
    [DependsOn(
        typeof(BlazoriseQuartzApplicationContractsModule),
        typeof(AbpAspNetCoreMvcUiThemeSharedModule),
        typeof(AbpAutoMapperModule)
        )]
    public class BlazoriseQuartzWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(typeof(BlazoriseQuartzResource), typeof(BlazoriseQuartzWebModule).Assembly);
            });

            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(BlazoriseQuartzWebModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpToolbarOptions>(options =>
            {
                options.Contributors.Add(new BlazoriseQuartzToolbarContributor());
            });

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<BlazoriseQuartzWebModule>();
            });

            context.Services.AddAutoMapperObjectMapper<BlazoriseQuartzWebModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<BlazoriseQuartzWebModule>(validate: true);
            });

            Configure<RazorPagesOptions>(options =>
            {
                //Configure authorization.
            });
            
            Configure<AbpBundlingOptions>(options =>
            {
                options
                    .StyleBundles
                    .Configure(StandardBundles.Styles.Global, bundle => {
                        bundle.AddContributors(typeof(PmNotificationStyleBundleContributor));
                    });
                
                options
                    .ScriptBundles
                    .Configure(StandardBundles.Scripts.Global, bundle => {
                        bundle.AddContributors(typeof(PmNotificationScriptBundleContributor));
                    });
            });
        }
    }
}
