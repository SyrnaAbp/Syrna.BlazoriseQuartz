using Syrna.BlazoriseQuartz.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Syrna.BlazoriseQuartz
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(BlazoriseQuartzEntityFrameworkCoreTestModule)
        )]
    public class BlazoriseQuartzDomainTestModule : AbpModule
    {
        
    }
}
