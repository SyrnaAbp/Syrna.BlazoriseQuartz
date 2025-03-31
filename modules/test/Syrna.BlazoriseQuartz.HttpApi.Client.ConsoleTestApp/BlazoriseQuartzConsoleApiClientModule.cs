using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Syrna.BlazoriseQuartz
{
    [DependsOn(
        typeof(BlazoriseQuartzHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class BlazoriseQuartzConsoleApiClientModule : AbpModule
    {
        
    }
}
