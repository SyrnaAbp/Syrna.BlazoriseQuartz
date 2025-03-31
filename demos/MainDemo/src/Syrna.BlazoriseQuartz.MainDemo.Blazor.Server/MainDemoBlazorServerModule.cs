using Volo.Abp.Modularity;

namespace Syrna.BlazoriseQuartz.MainDemo.Blazor.Server;

[DependsOn(
    typeof(MainDemoBlazorModule)
)]
public class MainDemoBlazorServerModule : AbpModule
{

}
