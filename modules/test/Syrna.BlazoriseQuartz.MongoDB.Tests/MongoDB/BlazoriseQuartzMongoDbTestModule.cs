using System;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace Syrna.BlazoriseQuartz.MongoDB
{
    [DependsOn(
        typeof(BlazoriseQuartzTestBaseModule),
        typeof(BlazoriseQuartzMongoDbModule)
        )]
    public class BlazoriseQuartzMongoDbTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = MongoDbFixture.GetRandomConnectionString();
            });
        }
    }
}