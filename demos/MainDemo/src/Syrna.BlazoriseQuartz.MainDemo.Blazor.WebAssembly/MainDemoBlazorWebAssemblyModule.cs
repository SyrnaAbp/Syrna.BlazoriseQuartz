using Syrna.BlazoriseQuartz.MainDemo.Blazor;
using Volo.Abp.Modularity;

namespace Syrna.BlazoriseQuartz.MainDemo.Blazor.WebAssembly;

[DependsOn(
    typeof(MainDemoBlazorModule)
)]
public class MainDemoBlazorWebAssemblyModule : AbpModule
{
}
