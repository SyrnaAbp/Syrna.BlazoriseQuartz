using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Syrna.BlazoriseQuartz.MongoDB
{
    [DependsOn(
        typeof(BlazoriseQuartzDomainModule),
        typeof(AbpMongoDbModule)
        )]
    public class BlazoriseQuartzMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<BlazoriseQuartzMongoDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
            });
        }
    }
}
