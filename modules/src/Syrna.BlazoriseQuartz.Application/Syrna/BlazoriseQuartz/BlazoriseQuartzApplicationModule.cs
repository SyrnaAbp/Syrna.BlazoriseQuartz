using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace Syrna.BlazoriseQuartz
{
    [DependsOn(
        typeof(BlazoriseQuartzDomainModule),
        typeof(BlazoriseQuartzApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule)
        )]
    public class BlazoriseQuartzApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<BlazoriseQuartzApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<BlazoriseQuartzApplicationModule>();
            });
        }
    }
}
