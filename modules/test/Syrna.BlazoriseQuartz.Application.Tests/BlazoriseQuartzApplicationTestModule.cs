using Volo.Abp.Modularity;

namespace Syrna.BlazoriseQuartz
{
    [DependsOn(
        typeof(BlazoriseQuartzApplicationModule),
        typeof(BlazoriseQuartzDomainTestModule)
        )]
    public class BlazoriseQuartzApplicationTestModule : AbpModule
    {

    }
}
