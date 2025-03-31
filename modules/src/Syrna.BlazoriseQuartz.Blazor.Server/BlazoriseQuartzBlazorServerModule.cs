using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace Syrna.BlazoriseQuartz.Blazor.Server
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsServerThemingModule),
        typeof(BlazoriseQuartzBlazorModule)
        )]
    public class BlazoriseQuartzBlazorServerModule : AbpModule
    {
        
    }
}