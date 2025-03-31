using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.Authorization;

namespace Syrna.BlazoriseQuartz
{
    [DependsOn(
        typeof(BlazoriseQuartzDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class BlazoriseQuartzApplicationContractsModule : AbpModule
    {

    }
}
