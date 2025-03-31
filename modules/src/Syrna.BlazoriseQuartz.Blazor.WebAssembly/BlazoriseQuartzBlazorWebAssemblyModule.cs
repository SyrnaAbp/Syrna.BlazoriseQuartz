using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace Syrna.BlazoriseQuartz.Blazor.WebAssembly
{
    [DependsOn(
        typeof(BlazoriseQuartzBlazorModule),
        typeof(BlazoriseQuartzHttpApiClientModule),
        typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
        )]
    public class BlazoriseQuartzBlazorWebAssemblyModule : AbpModule
    {
        
    }
}