using Localization.Resources.AbpUi;
using Syrna.BlazoriseQuartz.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Syrna.BlazoriseQuartz
{
    [DependsOn(
        typeof(BlazoriseQuartzApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class BlazoriseQuartzHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(BlazoriseQuartzHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<BlazoriseQuartzResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
