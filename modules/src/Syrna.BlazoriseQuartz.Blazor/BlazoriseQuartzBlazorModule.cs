using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Components.Web.Theming;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AspNetCore.Components.Web.Theming.Toolbars;
using Volo.Abp.AutoMapper;
using Volo.Abp.BlazoriseUI;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace Syrna.BlazoriseQuartz.Blazor
{
    [DependsOn(
        typeof(BlazoriseQuartzApplicationContractsModule),
        typeof(AbpAspNetCoreComponentsWebThemingModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpBlazoriseUIModule)
        )]
    public class BlazoriseQuartzBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpToolbarOptions>(options =>
            {
                options.Contributors.Add(new BlazoriseQuartzToolbarContributor());
            });

            context.Services.AddAutoMapperObjectMapper<BlazoriseQuartzBlazorModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<BlazoriseQuartzBlazorAutoMapperProfile>(validate: true);
            });

            context.Services.AddAutoMapperObjectMapper<BlazoriseQuartzBlazorModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<BlazoriseQuartzBlazorModule>(validate: true);
            });
            
            //Configure<AbpNavigationOptions>(options =>
            //{
            //    options.MenuContributors.Add(new BlazoriseQuartzMenuContributor());
            //});

            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(BlazoriseQuartzBlazorModule).Assembly);
            });
        }
    }
}