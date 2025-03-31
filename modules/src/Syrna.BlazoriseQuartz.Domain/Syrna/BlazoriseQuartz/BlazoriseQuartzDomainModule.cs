using Volo.Abp.Modularity;

namespace Syrna.BlazoriseQuartz
{
    [DependsOn(
        typeof(BlazoriseQuartzDomainSharedModule)
        )]
    public class BlazoriseQuartzDomainModule : AbpModule
    {

    }
}
