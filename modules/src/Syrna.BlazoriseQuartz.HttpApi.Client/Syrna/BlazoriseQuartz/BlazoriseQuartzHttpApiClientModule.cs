using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Syrna.BlazoriseQuartz
{
    [DependsOn(
        typeof(BlazoriseQuartzApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class BlazoriseQuartzHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = BlazoriseQuartzRemoteServiceConsts.RemoteServiceName;

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(BlazoriseQuartzApplicationContractsModule).Assembly,
                RemoteServiceName
            );
            
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<BlazoriseQuartzApplicationContractsModule>();
            });
        }
    }
}
